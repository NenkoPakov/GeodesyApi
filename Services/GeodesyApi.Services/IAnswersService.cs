using GeodesyApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeodesyApi.Services
{
   public interface IAnswersService
    {
        IQueryable<Answer> GetByQuestionId(int questionId);
    }
}
