using AutoMapper;
using Ganss.XSS;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeodesyApi.Web.ViewModels.News
{
    public class CreateNewsViewModel : IMapTo<GeodesyApi.Data.Models.News>
    {
        //private IFormFile image;

        public string Title { get; set; }

        public string Content { get; set; }

        public IFormFile Image { get; set; }

        //public IFormFile Image
        //{
        //    get
        //    {
        //        if (this.image == null)
        //        {
        //            using (var stream = File.OpenRead(@"..\wwwroot\img\newsDefaultImage.jpg"))
        //            {
        //                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
        //                {
        //                    Headers = new HeaderDictionary(),
        //                    ContentType = "image/jpg"
        //                };
        //
        //                this.image = file;
        //            }
        //        }
        //
        //            return this.image;
        //    }
        //
        //    set
        //    {
        //        this.image = value;
        //    }
        //}

        public NewsType Category { get; set; }

        public NewsGroupType Group { get; set; }

        public DateTime CreatedOn { get; set; }



    }
}
