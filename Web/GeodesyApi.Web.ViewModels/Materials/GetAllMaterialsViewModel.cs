using AutoMapper;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Materials
{
    public class GetAllMaterialsViewModel:IMapFrom<GetMaterialViewModel>
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public ICollection<GetMaterialViewModel> Materials { get; set; }
    }
}
