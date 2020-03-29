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
        public IEnumerable<GetMaterialViewModel> Materials { get; set; }
    }
}
