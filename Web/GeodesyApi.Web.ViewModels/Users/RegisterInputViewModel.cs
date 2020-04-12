using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Users
{
    public class RegisterInputModel :IMapTo<ApplicationUser>
    {
        [Required(ErrorMessage ="Потребителското име е задължително и трябва да е между 2 и 50 символа")]
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

       
        [Range(0, 10000,ErrorMessage = "Факултетният номер трябва да е между 1 и 10000")]
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

    }
}
