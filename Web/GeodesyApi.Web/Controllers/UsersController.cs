using GeodesyApi.Data.Models;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class UsersController : Controller
    {

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager
            )
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this.RoleManager = roleManager;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public SignInManager<ApplicationUser> SignInManager { get; }

        public RoleManager<ApplicationRole> RoleManager { get; }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel loginInputModel)
        {
            var username = loginInputModel.Username;
            var password = loginInputModel.Password;


            await this.SignInManager.PasswordSignInAsync(username, password, true, true);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInputModel registerInputModel)
        {
            var username = registerInputModel.Username;
            var firstName = registerInputModel.FirstName;
            var lastName = registerInputModel.LastName;
            var email = registerInputModel.Email;
            var phoneNumber = registerInputModel.PhoneNumber;
            var facultyNumber = registerInputModel.FacultyNumber;
            var password = registerInputModel.Password;

            var result = await this.UserManager.CreateAsync(new ApplicationUser()
            {
                UserName = username,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                //EmailConfirmed = true,
                PhoneNumber = phoneNumber,
                FacultyNumber = facultyNumber,
            }, password);

            return this.Redirect("/Users/Login");
        }


        public async Task<IActionResult> Logout()
        {
            await this.SignInManager.SignOutAsync();

            return this.Redirect("/");
        }
    }
}
