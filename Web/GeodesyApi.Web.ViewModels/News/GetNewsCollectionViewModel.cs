using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.News
{
    public class GetNewsCollectionViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<GetNewsViewModel> News { get; set; }
    }
}
