using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs;
using TopLearn.Core.Generator;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.User;
using TopLearn.DataLayer.Entities.User.Wallet;

namespace TopLearn.Core.Services
{
    public class UserService : IUserService
    {
        private TopLearnContext _context;

        public UserService(TopLearnContext context)
        {
            _context = context;
        }


        public bool ActiveAccount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault(c => c.ActiveCode == activeCode);

            if (user==null || user.IsActive)
            {
                return false;
            }

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            _context.SaveChanges();

            return true;
        }


        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public int AddUserFromAdmin(CreateUserViewModel user)
        {
            User addUser = new User();
            addUser.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            addUser.ActiveCode = NameGenerator.GenerateUniqCode();
            addUser.Email = user.Email;
            addUser.IsActive = true;
            addUser.RegisterDate = DateTime.Now;
            addUser.UserName = user.UserName;

            #region Save Avatar

            //Save New Image

            if (user.UserAvatar != null)
            {
                string imagePath = "";
                addUser.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(user.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", addUser.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }
            }

            #endregion

            return AddUser(addUser);

        }

        public int AddWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet.WalletId;
        }


        public int BalanceUserWallet(string username)
        {
            var userId = GetUserIdbyUsername(username);

            var Enter = _context.Wallets
                .Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPay)
                .Select(w=>w.Amount).ToList();

            var Exit = _context.Wallets
                .Where(w => w.UserId == userId && w.TypeId == 2 )
                .Select(w=>w.Amount).ToList();

            return (Enter.Sum() - Exit.Sum());
        }


        public void ChangeUserPassword(string username, string newPassword)
        {
            var user = GetUserByUsername(username);

            user.Password = PasswordHelper.EncodePasswordMd5(newPassword);

            UpdateUser(user);
        }


        public int ChargeWallet(string username, int amount, string description, bool ispay = false)
        {
            Wallet wallet = new Wallet()
            {
                Amount=amount,
                CreateDate=DateTime.Now,
                IsPay=ispay,
                Description=description,
                TypeId = 1,
                UserId=GetUserIdbyUsername(username)
            };

            return AddWallet(wallet);
        }


        public bool CompareOldPassword(string oldpassword, string username)
        {           
            var hashOldPassword = PasswordHelper.EncodePasswordMd5(oldpassword);

            return _context.Users.Any(c => c.Password == hashOldPassword && c.UserName == username);
        }

        public void DeleteUser(int userId)
        {
            User user = GetUserById(userId);
            user.IsDelete = true;
            UpdateUser(user);
        }

        public void EditProfile(string username, EditProfileViewModel profile)
        {
            if (profile.UserAvatar != null)
            {
                string imagePath = "";

                //Delete old Image
                if (profile.AvatarName != "Defult.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                //Save New Image
                profile.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(profile.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.UserAvatar.CopyTo(stream);
                }

            }

            var user = GetUserByUsername(username);
            user.UserName = profile.UserName;
            user.Email = profile.Email;
            user.UserAvatar = profile.AvatarName;

            UpdateUser(user);

        }

        public void EditUserFromAdmin(EditUserViewModel editUser)
        {
            User user = GetUserById(editUser.UserId);
            user.Email = editUser.Email;
            if (!string.IsNullOrEmpty(editUser.Password))
            {
                user.Password = PasswordHelper.EncodePasswordMd5(editUser.Password);
            }

            if (editUser.UserAvatar != null)
            {
                //Delete old Image
                if (editUser.AvatarName != "Defult.jpg")
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editUser.AvatarName);
                    if (File.Exists(deletePath))
                    {
                        File.Delete(deletePath);
                    }
                }

                //Save New Image
                user.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(editUser.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUser.UserAvatar.CopyTo(stream);
                }
            }

            UpdateUser(user);
        }

        public EditProfileViewModel GetDataForEditeProfileUser(string username)
        {
            return _context.Users.Where(c=>c.UserName==username).Select(c=> new EditProfileViewModel()
            { 
               UserName=c.UserName,
               Email=c.Email,
               AvatarName=c.UserAvatar
            }).Single();
        }

        public UserForAdminViewModel GetDeleteUsers(int pageId = 1, string FilterEmail = "", string filterUserName = "")
        {
            IQueryable<User> result = _context.Users.IgnoreQueryFilters().Where(u => u.IsDelete); 

            if (!string.IsNullOrEmpty(FilterEmail))
            {
                result = result.Where(u => u.Email.Contains(FilterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(u => u.UserName.Contains(filterUserName));
            }

            // show item in a page
            int take = 20;
            int skip = (pageId - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();

            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();


            return list;
        }

        public SideBarUserPanelViewModel GetSideBarUserPanelData(string username)
        {
            return _context.Users.Where(c => c.UserName == username).Select(c=> new SideBarUserPanelViewModel() 
            { 
                UserName=c.UserName,
                ImageName=c.UserAvatar,
                RegisterDate=c.RegisterDate
            }).Single();
        }


        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(c => c.ActiveCode == activeCode);
        }


        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(c => c.Email == email);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(c => c.UserName == username);
        }

        public EditUserViewModel GetUserForShowInEditMode(int userId)
        {
            return _context.Users.Where(p => p.UserId == userId)
                .Select(p => new EditUserViewModel()
                {
                    UserId=p.UserId,
                    UserName = p.UserName,
                    AvatarName = p.UserAvatar,
                    Email = p.Email,
                    UserRoles = p.UserRoles.Select(r => r.RoleId).ToList()
                }).Single();
        }

        public int GetUserIdbyUsername(string username)
        {
            return _context.Users.Single(c => c.UserName == username).UserId;
        }


        public InformationUserViewModel GetUserInformation(string username)
        {
            var user = GetUserByUsername(username);

            InformationUserViewModel information = new InformationUserViewModel();

            information.UserName = user.UserName;
            information.Email = user.Email;           
            information.RegisterDate = user.RegisterDate;
            information.Wallet = BalanceUserWallet(username);

            return information;
        }

        public InformationUserViewModel GetUserInformation(int userId)
        {
            var user = GetUserById(userId);
            InformationUserViewModel information = new InformationUserViewModel();

            information.UserName = user.UserName;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;
            information.Wallet = BalanceUserWallet(user.UserName);

            return information;
        }

        public UserForAdminViewModel GetUsers(int pageId = 1, string FilterEmail = "", string filterUserName = "")
        {
            IQueryable<User> result = _context.Users;

            if (!string.IsNullOrEmpty(FilterEmail))
            {
                result = result.Where(u => u.Email.Contains(FilterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(u => u.UserName.Contains(filterUserName));
            }

            // show item in a page
            int take = 20;
            int skip = (pageId - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();

            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            

            return list;
        }

        public Wallet GetWalletByWalletId(int walletid)
        {
            return _context.Wallets.Find(walletid);
        }

        public List<WalletViewModel> GetWalletUser(string username)
        {
            int userId = GetUserIdbyUsername(username);

            return _context.Wallets
                .Where(w=>w.IsPay && w.UserId == userId)
                .Select(w=> new WalletViewModel()
                {
                    Amount=w.Amount,
                    Description=w.Description,
                    DateTime=w.CreateDate,
                    Type=w.TypeId
                }).ToList();
        }


        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }


        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(c => c.UserName == userName);
        }


        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixEmail(login.Email);
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == hashPassword);
        }


        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();

        }

        public void UpdateWallet(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            _context.SaveChanges();
        }
    }
}
