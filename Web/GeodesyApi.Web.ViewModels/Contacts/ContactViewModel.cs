using AutoMapper;
using Ganss.XSS;
using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Contacts
{
    public class ContactViewModel : IMapTo<Contact>, IHaveCustomMappings
    {
        [Required(ErrorMessage = "Името е задължителна и трябва да е между 2 и 50 символа")]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Имейлът е задължителен")]
        [EmailAddress(ErrorMessage = "Невалиден имейл")]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Съдържанието е задължително и трябва да е между 2 и 500 символа")]
        [MinLength(2)]
        [MaxLength(500)]
        [Display(Name = "Съдържание")]
        public string Message { get; set; }

        public string SanitizedMessage => new HtmlSanitizer().Sanitize(this.Message);

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Contact, ContactViewModel>()
                .ForMember(m => m.Message, options =>
                {
                    options.MapFrom(p => this.SanitizedMessage);
                });
        }
    }
}
