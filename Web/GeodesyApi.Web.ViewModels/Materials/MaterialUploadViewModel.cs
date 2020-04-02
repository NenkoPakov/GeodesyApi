using AutoMapper;
using Ganss.XSS;
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

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public MaterialsType Category { get; set; }

        public ICollection<IFormFile> Files { get; set; }


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Material, MaterialUploadViewModel>()
                .ForMember(m => m.Description, options =>
                {
                    options.MapFrom(p => this.SanitizedDescription);
                });
        }
    }
}
