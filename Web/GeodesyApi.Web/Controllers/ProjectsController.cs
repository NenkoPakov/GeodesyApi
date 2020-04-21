using GeodesyApi.Data.Models;
using GeodesyApi.Services;
using GeodesyApi.Web.ViewModels.Projects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class ProjectsController:BaseController
    {
        public ProjectsController(UserManager<ApplicationUser> userManager, IProjectsService projectsService)
        {
            this.UserManager = userManager;
            this.ProjectsService = projectsService;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public IProjectsService ProjectsService { get; }

        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel input)
        {
            var user = await this.UserManager.GetUserAsync(this.User);

            var news = await this.ProjectsService.CreateProject(input, user);

            return this.View();
        }
    }
}
