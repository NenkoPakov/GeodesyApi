using Ganss.XSS;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.News
{
    public class CreateNewsViewModel : IMapTo<GeodesyApi.Data.Models.News>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public IFormFile Image { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public NewsType Category { get; set; }

        public NewsGroupType Group { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
