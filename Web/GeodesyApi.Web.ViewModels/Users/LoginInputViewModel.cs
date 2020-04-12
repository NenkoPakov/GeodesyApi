using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Users
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Потребителското име е задължително и трябва да е между 2 и 50 символа")]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Потребителско име")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

    }
}
