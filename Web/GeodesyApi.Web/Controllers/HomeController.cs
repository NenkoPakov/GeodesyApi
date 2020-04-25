namespace GeodesyApi.Web.Controllers
{
    using GeodesyApi.Services;
    using GeodesyApi.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        public HomeController(INewsService newsService)
        {
            NewsService = newsService;
        }

        public INewsService NewsService { get; }

        [HttpGet("/")]
        public IActionResult Index()
        {
            var news = this.NewsService.GetLastNews();

            return this.View(news);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
