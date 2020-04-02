using AutoMapper;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.News;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class NewsController : BaseController
    {
        private const int NewsPerPage = 5;

        public NewsController(UserManager<ApplicationUser> userManager, INewsService newsService)
        {
            this.UserManager = userManager;
            this.NewsService = newsService;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public INewsService NewsService { get; }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsViewModel input)
        {
            var user = await this.UserManager.GetUserAsync(this.User);

            var news = await this.NewsService.CreateNews(input, user);

            return this.RedirectToAction("GetNews");
        }

        [Route("News/{page}")]
        [Route("News/{category}/{page}")]
        //[Route("News/{category}/{newsId}")]
        public async Task<IActionResult> GetNews(NewsGroupType? category, int? newsId, int page = 1)
        {
            var news = this.NewsService.GetNews(category,NewsPerPage, (page - 1) * NewsPerPage);

            var count = this.NewsService.GetCount();
            news.PagesCount = (int)Math.Ceiling((double)count / NewsPerPage);

            if (news.PagesCount == 0)
            {
                news.PagesCount = 1;
            }

            news.CurrentPage = page;

            return this.View(news);
        }
    }
}
