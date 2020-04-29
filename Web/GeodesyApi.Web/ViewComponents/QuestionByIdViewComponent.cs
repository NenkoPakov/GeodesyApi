using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeodesyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeodesyApi.Web.ViewComponents
{
    [ViewComponent(Name ="QuestionById")]
    public class QuestionByIdViewComponent : ViewComponent
    {
        public QuestionByIdViewComponent(IQuestionsService questionsService)
        {
            this.QuestionsService = questionsService;
        }

        public IQuestionsService QuestionsService { get; }

        public IViewComponentResult Invoke(int questionId)
        {
            var viewModel = this.QuestionsService.GetById(questionId);

            return this.View(viewModel);
        }
    }
}
