using GeodesyApi.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Data.Models
{
    public class MaterialFiles : BaseDeletableModel<int>
    {
        public MaterialFiles()
        {
            //this.MaterialUniqueString = uniqueString;
        }

        [Required]
        public int MaterialId { get; set; }

        public virtual Material Material { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string FileUrl { get; set; }
    }
}
