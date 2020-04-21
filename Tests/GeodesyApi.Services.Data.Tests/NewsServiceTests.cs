using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GeodesyApi.Data;
using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Services;
using GeodesyApi.Data.Repositories;

using Microsoft.EntityFrameworkCore;

using Moq;

using Xunit;
using GeodesyApi.Web.ViewModels.News;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Web.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System;
using CloudinaryDotNet;
using System.Threading;
using GeodesyApi.Common.CloudinaryHelper;
using CloudinaryDotNet.Actions;
using static System.Net.WebRequestMethods;

namespace GeodesyApi.Services.Data.Tests
{
    public class NewsTestData
    {
        public static ApplicationUser User = new ApplicationUser()
        {
            FirstName = "testUser",
            LastName = "testUser",
            Id = "1-1-1-1",
            Email = "test@test.test",
        };

        public IQueryable<News> GetTestData()
        {
            return new List<News>
            {
                 new News {
                     Title = "TestNews1",
                     Content = "TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 ews1",
                     ImageUrl = "Test1",
                     Category = GeodesyApi.Data.Models.Enums.NewsType.BuyingNewTools,
                     Group = GeodesyApi.Data.Models.Enums.NewsGroupType.Event,
                     UserId = "UserIdTest1",
                 },
                 new News {
                     Title = "TestNews2",
                     Content = "TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 ews1",
                     ImageUrl = "Test2",
                     Category = GeodesyApi.Data.Models.Enums.NewsType.Meetings,
                     Group = GeodesyApi.Data.Models.Enums.NewsGroupType.News,
                     UserId = "UserIdTest1",
                 },
                 new News {
                     Title = "TestNews3",
                     Content = "TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 ews1",
                     ImageUrl = "Test3",
                     Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                     Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                     UserId = "UserIdTest1",
                 },
            }.AsQueryable();

        }

        static IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.pdf");

        public static List<CreateNewsViewModel> InputModels()
        {
            return new List<CreateNewsViewModel>
            {
                new CreateNewsViewModel
                {
                    Title = "TestNews3",
                    Content = "TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 ews1",
                    Image =file,
                    Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                    Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                    CreatedOn = DateTime.UtcNow,
                },
                new CreateNewsViewModel
                {
                    Title = "TestNews2",
                    Content = "TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 ews1",
                    Image = file,
                    Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                    Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                    CreatedOn = DateTime.UtcNow,
                },
                new CreateNewsViewModel
                {
                    Title = "TestNews1",
                    Content = "TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 ews1",
                    Image = file,
                    Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                    Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                    CreatedOn = DateTime.UtcNow,
                },
            };
        }
    }

    public class NewsServiceTests
    {
        protected Mock<IDeletableEntityRepository<News>> NewsRepository { get; set; }

        private Mock<IDeletableEntityRepository<ApplicationUser>> UserManager { get; set; }

        private Mock<ICloudinaryService> Cloydinary { get; set; }

        private INewsService NewsService { get; set; }

        public NewsServiceTests()
        {
            this.NewsRepository = new Mock<IDeletableEntityRepository<News>>();

            this.NewsRepository.SetupAllProperties();

            this.UserManager = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            Account account = new Account(
                "dv3tfjvk0",
                "834565789315234",
                "fh3CxN8m5yoWHhCuxfl6xQJ50hQ");


            this.Cloydinary = new Mock<ICloudinaryService>();
            this.NewsService = new NewsService(this.NewsRepository.Object, this.UserManager.Object, Cloydinary.Object);
        }


        [Fact]
        public void CreateNewsShouldReturnValidItemOfTypeNews()
        {
            //RawUploadParams uploadParams = new RawUploadParams
            //{
            //    File = new FileDescription("spreadsheet2.xls", new MemoryStream()),
            //    PublicId = "sample_spreadsheet2"
            //};
            //Task<RawUploadResult> uploadResult = await Cloydinary.Upload(uploadParams, "raw");

            var moqCloudinaryService = new Mock<ICloudinaryService>();
            var moqIFormFile = new Mock<IFormFile>();
            moqCloudinaryService.Setup(x => x.UploadAsync(moqIFormFile.Object))
                .ReturnsAsync("http://test.com");

            var news = new List<CreateNewsViewModel> 
            { 

                new CreateNewsViewModel
            {
                Title = "TestNews3",
                Content = "TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 TestNews3 ews1",
                Image = moqIFormFile.Object,
                Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                CreatedOn = DateTime.UtcNow,
            },
                new CreateNewsViewModel
                {
                    Title = "TestNews2",
                    Content = "TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 TestNews2 ews1",
                    Image = moqIFormFile.Object,
                    Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                    Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                    CreatedOn = DateTime.UtcNow,
                },
                new CreateNewsViewModel
                {
                    Title = "TestNews1",
                    Content = "TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 TestNews1 ews1",
                    Image = moqIFormFile.Object,
                    Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                    Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                    CreatedOn = DateTime.UtcNow,
                },
            };

            //var news = NewsTestData.InputModels();

             foreach (var item in news)
             {
                 this.NewsService.CreateNews(item, NewsTestData.User);
             }
            
            Assert.Equal(news.Count(), NewsRepository.Object.AllAsNoTracking().Count());
            }
    }
}

