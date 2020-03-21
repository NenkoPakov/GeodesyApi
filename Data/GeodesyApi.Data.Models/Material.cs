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
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public MaterialsType Category { get; set; }

        [Required]
        public string FileUrl { get; set; }
    }
}
