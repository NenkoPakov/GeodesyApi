using GeodesyApi.Data.Common.Models;
using GeodesyApi.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Data.Models
{
    public class Material : BaseDeletableModel<int>
    {
        public Material()
        {
            this.FilesUrls = new List<MaterialFiles>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public MaterialsType Category { get; set; }

        public ICollection<MaterialFiles> FilesUrls { get; set; }
    }
}
