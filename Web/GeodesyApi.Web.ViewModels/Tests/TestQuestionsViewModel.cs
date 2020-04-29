using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels.Tests
{
    public class TestQuestionViewModel : IMapFrom<Test>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public TestSubjectType Subject { get; set; }

        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}
