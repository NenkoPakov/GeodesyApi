using GeodesyApi.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Data.Models
{
    public class Answer : BaseModel<int>
    {
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; } = false;

        [Required]
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
