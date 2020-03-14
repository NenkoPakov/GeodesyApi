using GeodesyApi.Data.Common.Models;
using GeodesyApi.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Data.Models
{
    public class Library : BaseModel<int>
    {
        [Required]
        public string Title { get; set; }

        //[Required]
        //public IdentityUser Author { get; set; }

        [Required]
        public LibraryType Categoty { get; set; }

        public byte[] Files { get; set; }
    }
}
