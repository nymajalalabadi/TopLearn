using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs;
using TopLearn.Core.Security;
using TopLearn.Core.Services.Interfaces;

namespace Toplearn.Web.Pages.Admin.Users
{
    [PermissionChecker(4)]
    public class EditUserModel : PageModel
    {
        private IPermissionService _permissionService;
        private IUserService _userService;

        public EditUserModel(IPermissionService permissionService, IUserService userService)
        {
            _permissionService = permissionService;
            _userService = userService;
        }

        [BindProperty]
        public EditUserViewModel editUserViewModel { get; set; }

        public void OnGet(int id)
        {
            editUserViewModel = _userService.GetUserForShowInEditMode(id);
            ViewData["Roles"] = _permissionService.GetRoles();
        }



        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.EditUserFromAdmin(editUserViewModel);

            //Edit Roles
            _permissionService.EditRolesUser(editUserViewModel.UserId, SelectedRoles);

            return RedirectToPage("Index");
        }
    }
}
