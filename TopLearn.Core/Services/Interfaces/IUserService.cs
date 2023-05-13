using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.DTOs;
using TopLearn.DataLayer.Entities.User;
using TopLearn.DataLayer.Entities.User.Wallet;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);

        bool IsExistEmail(string email);

        int AddUser(User user);

        User LoginUser(LoginViewModel login);

        User GetUserByEmail(string email);

        User GetUserById(int userId);

        User GetUserByActiveCode(string activeCode);

        User GetUserByUsername(string username);

        void UpdateUser(User user);

        bool ActiveAccount(string activeCode);

        void DeleteUser(int userId);


        #region User Panel

        InformationUserViewModel GetUserInformation(string username);

        InformationUserViewModel GetUserInformation(int userId);

        SideBarUserPanelViewModel GetSideBarUserPanelData(string username);

        EditProfileViewModel GetDataForEditeProfileUser(string username);
       
        void EditProfile(string username ,EditProfileViewModel profile);

        bool CompareOldPassword(string oldpassword , string username);

        void ChangeUserPassword(string username , string newPassword);

        int GetUserIdbyUsername(string username);
        #endregion



        #region Wallet

        int BalanceUserWallet(string username);

        List<WalletViewModel> GetWalletUser(string username);

        int ChargeWallet(string username , int amount, string description ,bool ispay=false);

        int AddWallet(Wallet wallet);

        Wallet GetWalletByWalletId(int walletid);

        void UpdateWallet(Wallet wallet);

        #endregion



        #region Admin Panel

        UserForAdminViewModel GetUsers(int pageId=1,string FilterEmail="",string filterUserName="" );

        int AddUserFromAdmin(CreateUserViewModel user);

        EditUserViewModel GetUserForShowInEditMode(int userId);

        void EditUserFromAdmin(EditUserViewModel editUser);

        UserForAdminViewModel GetDeleteUsers(int pageId = 1, string FilterEmail = "", string filterUserName = "");

        #endregion
    }
}
