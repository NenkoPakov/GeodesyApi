using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeodesyApi.Services
{
    public class TestsService : ITestsService
    {
        public TestsService(IRepository<Test> testsRepository, IQuestionsService questionsService)
        {
            this.TestsRepository = testsRepository;
            this.QuestionsService = questionsService;
        }

        public IRepository<Test> TestsRepository { get; }

        public IQuestionsService QuestionsService { get; }

        public List<QuestionViewModel> GetQuestionsByTestId(int testId)
        {
           return this.QuestionsService
                .GetByTestId(testId)
                .To<QuestionViewModel>()
                .ToList();
        }

        public TestQuestionViewModel GetById(int testId)
        {
            var test = this.TestsRepository
                 .All()
                 .Where(x => x.Id == testId)
                 .To<TestQuestionViewModel>()
                 .FirstOrDefault();

            return test;
        }

        public ICollection<TestQuestionViewModel> GetAllForIndexPage()
        {
            var tests = new List<TestQuestionViewModel>();

            var testFromRepository = this.TestsRepository
                .All()
                .To<TestQuestionViewModel>();

            foreach (var test in testFromRepository)
            {
                tests.Add(this.GetById(test.Id));
            }

            return tests;
        }
    }
}
