using Ganss.XSS;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.News
{
    public class GetNewsViewModel : IMapFrom<GeodesyApi.Data.Models.News>
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

        public string ImageUrl { get; set; }

        public virtual IEnumerable<NewsCommentViewModel> Comments { get; set; }
    }
}
