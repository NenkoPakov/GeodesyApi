using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.Materials;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace GeodesyApi.Services.Data.Tests
{
    public class MaterialsServiceTests : BaseServiceTests
    {
        public MaterialsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(GetMaterialViewModel).GetTypeInfo().Assembly);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "testUser",
                LastName = "testUser",
                Id = "1-1-1-1",
                Email = "test@test.test",
            };

            var files = new List<MaterialFiles>
                {
                    new MaterialFiles
                    {
                        FileUrl="test.pdf",
                        UserId=user.Id,
                        MaterialId=1,
                    },
                new MaterialFiles
                    {
                        FileUrl="test1.pdf",
                        UserId=user.Id,
                        MaterialId=1,
                    },
                new MaterialFiles
                    {
                        FileUrl="test2.pdf",
                        UserId=user.Id,
                        MaterialId=1,
                    },
                };

            this.DbContext.Add(new Material
            {
                Id = 1,
                Author = user,
                AuthorId = user.Id,
                FilesUrls = files,
                Title = "Test"
            });
            this.DbContext.Add(new Material
            {
                Id = 2,
                Author = user,
                AuthorId = user.Id,
                FilesUrls = files,
                Title = "Test1"
            });
            this.DbContext.Add(new Material
            {
                Id = 3,
                Author = user,
                AuthorId = user.Id,
                FilesUrls = files,
                Title = "Test2"
            });
            this.DbContext.Add(new Material
            {
                Id = 4,
                Author = user,
                AuthorId = user.Id,
                FilesUrls = files,
                Title = "Test3"
            });

            this.DbContext.SaveChanges();
        }

        private IMaterialsService MaterialsServiceMock => this.ServiceProvider.GetRequiredService<IMaterialsService>();

        [Fact]
        public void GetCountTest()
        {
            var result = this.MaterialsServiceMock.GetCount();

            Assert.Equal(this.DbContext.Materials.Count(), result);
        }


    }
}
