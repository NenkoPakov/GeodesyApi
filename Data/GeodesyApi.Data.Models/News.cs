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
    public class News : BaseModel<int>
    {
        //public News()
        //{
        //    this.Files = new HashSet<byte>();
        //}

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public NewsType Categoty { get; set; }

        [Required]
        public NewsGroupType Group { get; set; }

    }
}
