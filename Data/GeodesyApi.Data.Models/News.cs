using GeodesyApi.Data.Common.Models;
using GeodesyApi.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace GeodesyApi.Data.Models
{
    public class News : BaseDeletableModel<int>
    {
        public News()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Подкатегория")]
        public NewsType Category { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public NewsGroupType Group { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
