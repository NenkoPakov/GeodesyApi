using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Comments
{
    public class CommentInNewsViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public string UserUsername { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
