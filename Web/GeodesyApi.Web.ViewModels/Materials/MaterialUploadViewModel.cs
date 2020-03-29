using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Materials
{
    public class MaterialUploadViewModel : IMapTo<Material>
    {
        public string Title { get; set; }

        public MaterialsType Category { get; set; }

        public ICollection<IFormFile> Files { get; set; }
    }
}
