using GeodesyApi.Web.ViewModels.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeodesyApi.Services
{
    public interface ITestsService
    {
        List<QuestionViewModel> GetQuestionsByTestId(int testId);

        TestQuestionViewModel GetById(int testId);

        ICollection<TestQuestionViewModel> GetAllForIndexPage();
    }
}
