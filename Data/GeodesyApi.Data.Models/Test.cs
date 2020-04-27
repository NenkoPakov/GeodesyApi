using GeodesyApi.Data.Common.Models;
using GeodesyApi.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Data.Models
{
    public class Test : BaseModel<int>
    {
        public Test()
        {
            this.Questions = new List<Question>();
        }

        public string Title { get; set; }

        public TestSubjectType Subject { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
