using GeodesyApi.Data.Models;
using GeodesyApi.Web.ViewModels.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeodesyApi.Services
{
    public interface IQuestionsService
    {
        ICollection<QuestionViewModel> GetFullQuestionsByTestId(int testId);

        QuestionViewModel GetById(int id);

        IQueryable<Question> GetByTestId(int testId);
    }
}
