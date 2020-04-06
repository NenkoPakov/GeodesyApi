using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Comments
{
    public class CommentViewModel : IMapTo<Comment>
    {
        public int NewsId { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }
    }
}
