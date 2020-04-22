using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels.News
{
    public class EditNewsViewModel : IMapFrom<GeodesyApi.Data.Models.News>
    {
        [Required(ErrorMessage = "Заглавието е задължително и трябва да е между 2 и 50 символа")]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Съдържанието е задължително и трябва да е между 2 и 500 символа")]
        [MinLength(2)]
        [MaxLength(500)]
        [Display(Name = "Заглавие")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Изображението е задължително ")]
        [Display(Name = "Изображение")]
        public IFormFile Image { get; set; }

        [Display(Name = "Подкатегория")]
        public NewsType Category { get; set; }

        [Display(Name = "Категория")]
        public NewsGroupType Group { get; set; }
    }
}
