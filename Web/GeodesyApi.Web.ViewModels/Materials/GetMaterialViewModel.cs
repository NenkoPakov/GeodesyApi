using AutoMapper;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Materials
{
    public class GetMaterialViewModel :  IMapFrom<Material>,IMapTo<GetAllMaterialsViewModel>
    {
        public string Title { get; set; }

        public MaterialsType Category { get; set; }

        public string AuthorUserName { get; set; }

        public string FileUrl { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    //     configuration.CreateMap<Material,GetAllMaterialsViewModel>()
        //    //         .ForMember(m=>m.FileUrl,options=>
        //    //         {
        //    //             options.MapFrom(p=>p.)
        //    //         })
        //}
    }
}
