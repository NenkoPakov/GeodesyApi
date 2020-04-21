using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace GeodesyApi.Web.ViewModels.Projects
{
    public class CreateProjectViewModel : IMapTo<Project>
    {
        
        [Required]
        public string FullUrl { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public string Service { get; set; }

        public string Version { get; set; }

        [Required]
        public string Requerst { get; set; }

        [Required]
        public string Layer { get; set; }

        [Required]
        public string Bbox { get; set; }

        [Required]
        public string Width { get; set; }

        [Required]
        public string Hight { get; set; }

        [Required]
        public string Srs { get; set; }

        [Required]
        public string Format { get; set; }

        //private string _value;
        //public string CachedProperty
        //{
        //    get
        //    {
        //
        //
        //        SplitFullUrl(); // slow
        //
        //        return _value;
        //    }
        //}
        //
        //
        //private void SplitFullUrl()
        //{
        //    var a = new CreateProjectViewModel();
        //
        //    string decodeFullUrl = WebUtility.HtmlDecode(this.FullUrl);
        //
        //    var fullUrlTokens = decodeFullUrl.Split('?');
        //
        //    this.Url = fullUrlTokens[0];
        //
        //    var parameters = fullUrlTokens[1].Split('&');
        //
        //    foreach (PropertyInfo propertyInfo in this.GetType().GetProperties().Skip(4))
        //    {
        //        var value = parameters
        //            .Where(x => x.StartsWith(propertyInfo.Name.ToLower()))
        //            .FirstOrDefault();
        //        if (value != null)
        //        {
        //            value = value
        //             .Split('=', 2)
        //             .Last();
        //        }
        //
        //        var url = new Uri("http://localhost:8080/geoserver/PUP/wms?service=WMS&version=1.1.0&request=GetMap&layers=PUP%3APUP&bbox=324985.375%2C4693381.156%2C326327.783%2C4694455.67&width=768&height=614&srs=EPSG%3A7801&format=application/openlayers")
        //           ;
        //
        //        var param1 = HttpUtility.ParseQueryString(url.Query).AllKeys;
        //    }
        //}

    }
}
