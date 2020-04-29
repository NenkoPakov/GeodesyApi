using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public class QuestionsService : IQuestionsService
    {
        public QuestionsService(IRepository<Question> questionsRepository, IAnswersService answersService)
        {
            this.QuestionsRepository = questionsRepository;
            this.AnswersService = answersService;
        }

        public IRepository<Question> QuestionsRepository { get; }

        public IAnswersService AnswersService { get; }

        public ICollection<QuestionViewModel> GetFullQuestionsByTestId(int testId)
        {
            var fullQuestions = new List<QuestionViewModel>();

            var questions = this.GetByTestId(testId);

            foreach (var question in questions)
            {
                var fullQuestion = this.GetById(question.Id);

                fullQuestions.Add(fullQuestion);
            }

            return fullQuestions;
        }

        public QuestionViewModel GetById(int id)
        {
            var answers = this.AnswersService
                .GetByQuestionId(id)
                .To<AnswerViewModel>()
                .ToList();

            var question = this.QuestionsRepository
                .All()
                .Where(x => x.Id == id)
                .To<QuestionViewModel>()
                .FirstOrDefault();

            question.Answers = answers;

            return question;
        }

        public IQueryable<Question> GetByTestId(int testId)
        {
            return this.QuestionsRepository
                 .All()
                 .Where(x => x.TestId == testId);
        }
    }
}
