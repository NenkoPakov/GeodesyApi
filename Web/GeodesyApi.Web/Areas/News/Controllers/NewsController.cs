using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Areas.News.Controllers
{
    [Area("News")]
    [Authorize]
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
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.UserManager.GetUserAsync(this.User);

            var news = await this.NewsService.CreateNews(input, user);

            return this.RedirectToAction("GetNews");
        }

        [AllowAnonymous]
        [Route("News/News/All/{page?}")]
        public IActionResult GetNews(int page = 1)
        {
            var news = this.NewsService.GetNews(NewsPerPage, (page - 1) * NewsPerPage);

            if (news.News.Count == 0)
            {
                return this.BadRequest();
            }

            var count = this.NewsService.GetCount();

            news.PagesCount = (int)Math.Ceiling((double)count / NewsPerPage);

            if (news.PagesCount == 0)
            {
                news.PagesCount = 1;
            }

            news.CurrentPage = page;

            if (news.CurrentPage > news.PagesCount)
            {
                return this.BadRequest();
            }

            return this.View(news);
        }

        [AllowAnonymous]
        [Route("News/News/{category}/{page?}")]
        public IActionResult GetByCategory(NewsGroupType? category, int page = 1)
        {
            if (category == null)
            {
                return this.BadRequest();
            }

            var news = this.NewsService.GetByCategory(category, NewsPerPage, (page - 1) * NewsPerPage);

            var count = this.NewsService.GetCount(category);

            news.PagesCount = (int)Math.Ceiling((double)count / NewsPerPage);

            if (news.PagesCount == 0)
            {
                news.PagesCount = 1;
            }

            news.CurrentPage = page;

            if (news.CurrentPage > news.PagesCount)
            {
                return this.BadRequest();
            }

            return this.View("GetNews", news);
        }



        [Route("News/News/Details/{newsId}")]
        public async Task<IActionResult> GetNewsById(int newsId)
        {
            var news = this.NewsService.GetById(newsId);

            if (news == null)
            {
                return this.NotFound();
            }

            var newsViewModel = AutoMapperConfig.MapperInstance.Map<GetNewsViewModel>(news);

            return this.View("Details", newsViewModel);
        }

        public IActionResult Edit(int id)
        {
            var news = this.NewsService.GetById(id);

            if (news == null)
            {
                return this.NotFound();
            }

            var newsViewModel = AutoMapperConfig.MapperInstance.Map<EditNewsViewModel>(news);

            return this.View(newsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditNewsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.UserManager.GetUserAsync(this.User);

            var result = await this.NewsService.EditAsync(input, user);

            return this.RedirectToAction("GetNews");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedNews = await this.NewsService.DeleteAsync(id);

            return this.RedirectToAction("GetNews");
        }
    }
}
