using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Tests
{
    public class AnswerViewModel : IMapFrom<Answer>
    {
        [Required]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        [Required]
        public int QuestionId { get; set; }
    }
}
