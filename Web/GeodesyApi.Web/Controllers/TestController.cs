using GeodesyApi.Data.Models;
using GeodesyApi.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    [Authorize]
    [Authorize(Roles = Common.GlobalConstants.GeodesyApiAdminRoleName)]
    public class TestController : BaseController
    {
        public TestController(UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<IActionResult> CreateUser()
        {
            return this.Redirect("/Home/Index");
        }


        public IActionResult Test()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Test(Test input)
        {
            return this.View();
        }
    }
}
