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
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public NewsType Category { get; set; }

        [Required]
        public NewsGroupType Group { get; set; }
        
        public string ImageUrl { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
