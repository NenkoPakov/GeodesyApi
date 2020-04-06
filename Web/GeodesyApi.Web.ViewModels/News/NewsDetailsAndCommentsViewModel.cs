using GeodesyApi.Web.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.News
{
    public class NewsDetailsAndCommentsViewModel
    {
        public GetNewsViewModel News { get; set; }

        public CommentViewModel Comment { get; set; }
    }
}
