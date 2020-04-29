using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Tests
{
    public class SolveQuestionViewModel : IMapFrom<Question>
    {
        [Required]
        public string QuestionText { get; set; }

        [Required]
        public ICollection<AnswerViewModel> Answers { get; set; }

        public int TestId { get; set; }

        public virtual Test Test { get; set; }

        public string FullName { get; set; }

        public string FacultyNumber { get; set; }

    }
}
