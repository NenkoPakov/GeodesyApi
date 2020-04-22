using AutoMapper;
using Ganss.XSS;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Materials
{
    public class MaterialEditViewModel : IMapFrom<Material>
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително и трябва да е между 2 и 50 символа")]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Описание е задължително и трябва да е между 2 и 500 символа")]
        [MinLength(2)]
        [MaxLength(500)]
        [Display(Name = "Заглавие")]
        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        [Display(Name = "Категория")]
        public MaterialsType Category { get; set; }

        [Required(ErrorMessage = "Прикачването на файл е задължително")]
        [Display(Name = "Файл")]
        public ICollection<IFormFile> Files { get; set; }


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Material, MaterialUploadViewModel>()
                .ForMember(m => m.Description, options =>
                {
                    options.MapFrom(p => this.SanitizedDescription);
                });
        }
    }
}