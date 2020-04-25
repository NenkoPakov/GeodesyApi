using GeodesyApi.Data.Models;
using GeodesyApi.Services;
using GeodesyApi.Web.ViewModels.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    [Authorize]
    public class ProjectsController : BaseController
    {
        public ProjectsController(UserManager<ApplicationUser> userManager, IProjectsService projectsService)
        {
            this.UserManager = userManager;
            this.ProjectsService = projectsService;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public IProjectsService ProjectsService { get; }

        [AllowAnonymous]
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

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
