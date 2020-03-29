using GeodesyApi.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Data.Models
{
    public class Comment : BaseDeletableModel<int>
    {
        public int NewsId { get; set; }

        public virtual News News { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
