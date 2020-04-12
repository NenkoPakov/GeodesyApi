using GeodesyApi.Data.Models;
using GeodesyApi.Services;
using GeodesyApi.Web.ViewModels.Comments;
using GeodesyApi.Web.ViewModels.News;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class CommentsController : Controller
    {
        public CommentsController(UserManager<ApplicationUser> userManager, ICommentsService commentsService)
        {
            this.UserManager = userManager;
            this.CommentsService = commentsService;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public ICommentsService CommentsService { get; }

        [HttpPost]
        public async Task<IActionResult> Create(CommentViewModel input)
        {
            var user = await this.UserManager.GetUserAsync(this.User);

            await this.CommentsService.Create(input, user);

            return this.RedirectToAction("Details", "News", new { id = input.NewsId});
        }

        public async Task<bool> CanCreateComment()
        {
            var user = await this.UserManager.GetUserAsync(this.User);

            return default;
           // return this.CommentsService.CanCreate();
        }
    }
}
