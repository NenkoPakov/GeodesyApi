using GeodesyApi.Data;
using GeodesyApi.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class TestController : BaseController
    {
        public TestController(UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<IActionResult> CreateUser()
        {
            //var result = await this.UserManager.CreateAsync(new ApplicationUser()
            //{
            //    Email = "nenko_pakov@abv.bg",
            //    UserName = "nenko",
            //    EmailConfirmed = true,
            //    FirstName = "Nenko",
            //    LastName = "Pakov",
            //    PhoneNumber = "0888996096",
            //    FacultyNumber = 4691,
            //}, "nenko123");

            var result = await this.UserManager.CreateAsync(new ApplicationUser()
             {
                 Email = "hristo_dechev@abv.bg",
                 UserName = "dechev",
                 EmailConfirmed = true,
                 FirstName = "Hristo",
                 LastName = "Dechev",
                 PhoneNumber = "0888888888",
                 FacultyNumber = 0,
             }, "dechev123");


            return this.Redirect("/Home/Index");
        }
    }
}
