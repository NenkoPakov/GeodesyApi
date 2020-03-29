using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Web.ViewModels.News
{
    public class GetNewsCollectionViewModel
    {
        public IEnumerable<GetNewsViewModel> News { get; set; }
    }
}
