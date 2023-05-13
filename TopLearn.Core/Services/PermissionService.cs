using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.Permissions;
using TopLearn.DataLayer.Entities.User;

namespace TopLearn.Core.Services
{
    public class PermissionService : IPermissionService
    {

        private TopLearnContext _context;

        public PermissionService(TopLearnContext context)
        {
            _context = context;
        }

        public void AddPermissionsToRole(int roleId, List<int> permission)
        {
            foreach (var p in permission)
            {
                _context.RolePermission.Add(new RolePermission()
                {
                    RoleId=roleId,
                    PermissionId=p
                });
            }
            _context.SaveChanges();
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleId;
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _context.SaveChanges();
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            int userId = _context.Users.Single(p=>p.UserName==userName).UserId;

            //List ROLE Has USER 
            List<int> UserRoles = _context.UserRoles
                .Where(p => p.UserId == userId).Select(p => p.RoleId).ToList();

            if (!UserRoles.Any())
            {
                return false;
            }

            //List ROLE Has PERMISSION 
            List<int> RolePermission = _context.RolePermission
                .Where(p => p.PermissionId == permissionId).Select(p => p.RoleId).ToList();

            return RolePermission.Any(p => UserRoles.Contains(p));
        }

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }

        public void EditRolesUser(int userId, List<int> roleId)
        {

            //Delete All Roles User
            _context.UserRoles.Where(r => r.UserId == userId).ToList()
                .ForEach(r=>_context.UserRoles.Remove(r));

            //Add New Roles
            AddRolesToUser(roleId,userId);
        }

        public List<Permission> GetAllPermission()
        {
            return _context.Permission.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public List<int> PermissionsRole(int roleId)
        {
            return _context.RolePermission
                .Where(p => p.RoleId == roleId)
                .Select(p=>p.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleId, List<int> permissions)
        {
            _context.RolePermission.Where(p => p.RoleId == roleId)
                 .ToList().ForEach(p => _context.RolePermission.Remove(p));

            AddPermissionsToRole(roleId, permissions);
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }
    }
}
