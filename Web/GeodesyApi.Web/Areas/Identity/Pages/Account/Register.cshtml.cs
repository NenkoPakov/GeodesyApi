using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using GeodesyApi.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using GeodesyApi.Services;

namespace GeodesyApi.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> SignInManager;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly ILogger<RegisterModel> Logger;
        private readonly GeodesyApi.Services.Messaging.IEmailSender EmailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            GeodesyApi.Services.Messaging.IEmailSender emailSender,
            ICloudinaryService cloudinary)

        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this.Logger = logger;
            this.EmailSender = emailSender;
            this.Cloudinary = cloudinary;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public ICloudinaryService Cloudinary { get; }

        public class InputModel
        {
            [Display(Name = "Снимка")]
            public IFormFile Picture { get; set; }

            [Required(ErrorMessage = "Потребителското име е задължително и трябва да е между 2 и 50 символа")]
            [MinLength(2)]
            [MaxLength(50)]
            [Display(Name = "Потребителско име")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Името е задължително и трябва да е между 2 и 50 символа")]
            [MinLength(2)]
            [MaxLength(50)]
            [Display(Name = "Име")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Фамилията е задължителна и трябва да е между 2 и 50 символа")]
            [MinLength(2)]
            [MaxLength(50)]
            [Display(Name = "Фамилия")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Имейлът е задължителен")]
            [EmailAddress(ErrorMessage = "Невалиден имейл")]
            [Display(Name = "Имейл")]
            public string Email { get; set; }


            [Range(0, 10000, ErrorMessage = "Факултетният номер трябва да е между 1 и 10000")]
            [Display(Name = "Факултетен номер")]
            public int? FacultyNumber { get; set; }

            [MaxLength(10, ErrorMessage = "Невалиден телефонен номер")]
            [Display(Name = "Телефонен номер")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Паролата е задължителна")]
            [DataType(DataType.Password)]
            [MinLength(5, ErrorMessage = "Паролата трябва да е поне 5 символа")]
            [Display(Name = "Парола")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Паролата е задължителна")]
            [DataType(DataType.Password)]
            [MinLength(5, ErrorMessage = "Паролата трябва да е поне 5 символа")]
            [Display(Name = "Потвърди паролата")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;
            this.ExternalLogins = (await this.SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/");
            this.ExternalLogins = (await this.SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (this.ModelState.IsValid)
            { 
                var user = new ApplicationUser
                {
                    UserName = this.Input.Username,
                    FirstName = this.Input.FirstName,
                    LastName = this.Input.LastName,
                    Email = this.Input.Email,
                    FacultyNumber = this.Input.FacultyNumber,
                    PhoneNumber = this.Input.PhoneNumber,
                };

                var result = await this.UserManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    this.Logger.LogInformation("User created a new account with password.");

                    var code = await this.UserManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await this.EmailSender.SendEmailAsync(Input.Email, "Confirm your email",
                       GetEmailConfirmationHtml(Input.Username, HtmlEncoder.Default.Encode(callbackUrl)));

                    if (this.UserManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await this.SignInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();



        }

        public string GetEmailConfirmationHtml(string username, string confirmationLink)
        {
            return $"<div style=\"font-size:20px\">" +
                    $"<div>Здравей {username},</div>" +
                    $"<br>" +
                    $"<div>благодарим ти, че стана част от нашата общност.</div>" +
                    $"<div>Потвърди твоят акаунт чрез <a href='{confirmationLink}'>натискане на линка</a>.</div>" +
                    $"<br>" +
                    $"<div>Благодарим!</div>" +
                    $"</div>";
        }
    }
}
