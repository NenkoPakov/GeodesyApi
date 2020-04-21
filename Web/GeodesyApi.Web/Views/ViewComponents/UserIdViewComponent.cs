using GeodesyApi.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Views.ViewComponents
{
    public class UserIdViewComponent : ViewComponent
    {
        public UserIdViewComponent(UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public IViewComponentResult Invoke()
        {
            var userId = this.UserManager.GetUserId(this.UserClaimsPrincipal);
            return this.View(userId);
        }
    }
}
