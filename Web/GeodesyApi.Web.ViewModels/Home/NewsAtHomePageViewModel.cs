using Ganss.XSS;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Web.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Home
{
    public class NewsAtHomePageViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public NewsType Category { get; set; }

        public NewsGroupType Group { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Url => $"{this.Title.Replace(' ', '-')}";
    }
}
