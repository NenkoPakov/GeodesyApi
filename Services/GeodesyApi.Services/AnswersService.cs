using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeodesyApi.Services
{
    public class AnswersService : IAnswersService
    {
        public AnswersService(IRepository<Answer> answerRepository)
        {
            this.AnswerRepository = answerRepository;
        }

        public IRepository<Answer> AnswerRepository { get; }

        public IQueryable<Answer> GetByQuestionId(int questionId)
        {
            return this.AnswerRepository
                 .All()
                 .Where(x => x.QuestionId == questionId);
        }
    }
}
