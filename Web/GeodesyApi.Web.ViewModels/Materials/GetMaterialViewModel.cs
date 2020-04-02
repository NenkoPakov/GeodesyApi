using AutoMapper;
using Ganss.XSS;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Materials
{
    public class GetMaterialViewModel : IMapFrom<Material>, IMapTo<GetAllMaterialsViewModel>
    {
        public string Title { get; set; }

        public MaterialsType Category { get; set; }

        public string AuthorUserName { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                return this.Description.Length > 300
                        ? this.Description.Substring(0, 300) + "..."
                        : this.Description;
            }
        }

        public string FileUrl { get; set; }
    }
}
