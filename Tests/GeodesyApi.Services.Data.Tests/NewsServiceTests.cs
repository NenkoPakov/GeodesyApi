using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.News;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace GeodesyApi.Services.Data.Tests
{
    public class NewsServiceTest : BaseServiceTests
    {
        public NewsServiceTest()
        {
            AutoMapperConfig.RegisterMappings(typeof(GetNewsViewModel).GetTypeInfo().Assembly);

            this.DbContext.News.Add(new News
            {
                Title = "TestNews1",
                Content = "TestNews1",
                ImageUrl = "https://test.com",
                Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                CreatedOn = DateTime.UtcNow,
                User = user,
                UserId = user.Id,

            });
            this.DbContext.News.Add(new News
            {
                Title = "TestNews2",
                Content = "TestNews2",
                ImageUrl = "https://test.com",
                Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                CreatedOn = DateTime.UtcNow,
                User = user,
                UserId = user.Id,

            });
            this.DbContext.News.Add(new News
            {
                Title = "TestNews3",
                Content = "TestNews3",
                ImageUrl = "https://test.com",
                Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                CreatedOn = DateTime.UtcNow,
                User = user,
                UserId = user.Id,

            });

            this.DbContext.SaveChangesAsync().GetAwaiter().GetResult();
        }

        ApplicationUser user = new ApplicationUser
        {
            FirstName = "testUser",
            LastName = "testUser",
            Id = "1-1-1-1",
            Email = "test@test.test",
        };

        private INewsService NewsServiceMock => this.ServiceProvider.GetRequiredService<INewsService>();


        [Fact]
        public async Task GetById()
        {

            

            var expected = new News
            {
                Title = "TestNews1",
                Content = "TestNews1",
                ImageUrl = "https://test.com",
                Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                CreatedOn = DateTime.UtcNow,
                User = user,
                UserId = user.Id,
            };

            AutoMapperConfig.RegisterMappings(typeof(GetNewsViewModel).GetTypeInfo().Assembly);

            // var expectedNews = AutoMapperConfig.MapperInstance.Map<GetNewsViewModel>(expected);

            var result = this.NewsServiceMock.GetById(1);

            // var actualNews = AutoMapperConfig.MapperInstance.Map<GetNewsViewModel>(result);

            Assert.Equal(expected.Title, result.Title);
            Assert.Equal(expected.Content, result.Content);
            Assert.Equal(expected.Group, result.Group);
            Assert.Equal(expected.Category, result.Category);
            Assert.Equal(expected.User, result.User);
            Assert.Equal(expected.UserId, result.UserId);
        }

        [Fact]
        public async Task GetNewsTest()
        {
            var result = this.NewsServiceMock.GetNews();


            var expected = new List<News>
            {
                new News
            {
                Title = "TestNews1",
                Content = "TestNews1",
                ImageUrl = "https://test.com",
                Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                CreatedOn = DateTime.UtcNow,
                User = user,
                UserId = user.Id,

            },
            new News
            {
                Title = "TestNews2",
                Content = "TestNews2",
                ImageUrl = "https://test.com",
                Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                CreatedOn = DateTime.UtcNow,
                User = user,
                UserId = user.Id,

            },
            new News
            {
                Title = "TestNews3",
                Content = "TestNews3",
                ImageUrl = "https://test.com",
                Category = GeodesyApi.Data.Models.Enums.NewsType.Practice,
                Group = GeodesyApi.Data.Models.Enums.NewsGroupType.RecommendedForStudents,
                CreatedOn = DateTime.UtcNow,
                User = user,
                UserId = user.Id,

            },
            }.OrderByDescending(x=>x.CreatedOn)
            .ToList();

            Assert.Equal(expected.Count, result.News.Count);
            Assert.Equal(expected.FirstOrDefault().Title, result.News.FirstOrDefault().Title);
            Assert.Equal(expected.FirstOrDefault().Content, result.News.FirstOrDefault().Content);
            Assert.Equal(expected.Last().Title, result.News.Last().Title);
            Assert.Equal(expected.Last().UserId, result.News.Last().UserId);
        }
    }
}