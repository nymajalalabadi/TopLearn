using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Security;

namespace Toplearn.Web.Pages.Admin
{
    public class IndexModel : PageModel
    {

        [PermissionChecker(1)]
        public void OnGet()
        {
        }

       
    }
}
