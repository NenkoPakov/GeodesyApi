using GeodesyApi.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Data.Models
{
    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        public int NewsId { get; set; }

        public virtual News News { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(250)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
