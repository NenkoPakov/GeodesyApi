using GeodesyApi.Data.Models;
using GeodesyApi.Services;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.Tests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    [Authorize]
    public class TestsController : BaseController
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public ITestsService TestsService { get; }
        public IQuestionsService QuesionsService { get; }

        public TestsController(UserManager<ApplicationUser> userManager, ITestsService testsService, IQuestionsService quesionsService)
        {
            this.UserManager = userManager;
            this.TestsService = testsService;
            this.QuesionsService = quesionsService;
        }

        public async Task<IActionResult> CreateTest()
        {
            return this.Redirect("/Home/Index");
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var tests = this.TestsService.GetAllForIndexPage();

            var viewModel = new AllTestsViewModel();
            viewModel.Tests = tests;

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = this.TestsService.GetById(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Details()
        {
            var tests = this.TestsService.GetAllForIndexPage();

            var viewModel = new AllTestsViewModel();
            viewModel.Tests = tests;

            return this.View(viewModel);
        }


        [HttpPost]
        public IActionResult Entry()
        {
            return this.View();
        }
    }
}
