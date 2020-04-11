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
        private const int NewsPerPage = 10;

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

        [Route("News/All/{page?}")]
        public async Task<IActionResult> GetNews(int page = 1)
        {
            var news = this.NewsService.GetNews(NewsPerPage, (page - 1) * NewsPerPage);

            var count = this.NewsService.GetCount(news.News);

            news.PagesCount = (int)Math.Ceiling((double)count / NewsPerPage);

            if (news.PagesCount == 0)
            {
                news.PagesCount = 1;
            }

            news.CurrentPage = page;

            return this.View(news);
        }


        [Route("News/{category}/{page?}")]
        public async Task<IActionResult> GetByCategory(NewsGroupType? category, int page = 1)
        {
            var news = this.NewsService.GetByCategory(category, NewsPerPage, (page - 1) * NewsPerPage);

            var count = this.NewsService.GetCount(news.News);

            news.PagesCount = (int)Math.Ceiling((double)count / NewsPerPage);

            if (news.PagesCount == 0)
            {
                news.PagesCount = 1;
            }

            news.CurrentPage = page;

            return this.View("GetNews", news);
        }



        [Route("News/Details/{newsId}")]
        public async Task<IActionResult> GetNewsById(int newsId)
        {
            var news = this.NewsService.GetById(newsId);


            return this.View("Details", news);
        }


        //private int NewsCount() 
        //{
        //    var count = this.NewsService.GetCount();
        //    news.PagesCount = (int)Math.Ceiling((double)count / NewsPerPage);
        //
        //    if (news.PagesCount == 0)
        //    {
        //        news.PagesCount = 1;
        //    }
        //
        //    news.CurrentPage = page;
        //}

    }
}
