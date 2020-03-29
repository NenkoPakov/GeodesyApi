using AutoMapper;
using GeodesyApi.Data.Models;
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

            var news = await this.NewsService.CreateNews(input,user);

            return this.RedirectToAction("GetNews");
        }

        public async Task<IActionResult> GetNews(int? id)
        {
            var news = this.NewsService.GetNews(id);

            return this.View(news);
        }

        //[HttpPost]
        //public async Task<IActionResult> GetNews()
        //{
        //    var user = await this.UserManager.GetUserAsync(this.User);
        //
        //    var news = await this.NewsService.CreateNews(input.Title, input.Content, input.Category, input.Group, user.Id);
        //
        //    return this.RedirectToAction("GetNews");
        //}
    }
}
