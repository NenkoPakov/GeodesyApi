using GeodesyApi.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Data.Models
{
    public class Project:BaseDeletableModel<int>
    {
        [Required]
        public string Url { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public string Version { get; set; }

        [Required]
        public string Requerst { get; set; }

        [Required]
        public string Layer { get; set; }

        [Required]
        public string Bbox { get; set; }

        [Required]
        public string Width { get; set; }

        [Required]
        public string Hight { get; set; }

        [Required]
        public string Srs { get; set; }

        [Required]
        public string Format { get; set; }
    }
}
