using GeodesyApi.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeodesyApi.Data.Models
{
    public class Question : BaseModel<int>
    {
        public Question()
        {
            this.Answers = new List<Answer>();
        }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public ICollection<Answer> Answers { get; set; }

        public int TestId { get; set; }

        public virtual Test Test { get; set; }
    }
}
