using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.Materials;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace GeodesyApi.Services.Data.Tests
{
    public class MaterialsServiceTests : BaseServiceTests
    {
        public List<MaterialFiles> Files;

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

            this.Files = files;

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

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void GetByIdTest(int skipCount)
        {
            var result = this.MaterialsServiceMock.GetById(this.DbContext.Materials.Skip(skipCount).FirstOrDefault().Id);

            Assert.Equal(this.DbContext.Materials.Skip(skipCount).FirstOrDefault().Title, result.Title);
            Assert.Equal(this.DbContext.Materials.Skip(skipCount).FirstOrDefault().CreatedOn, result.CreatedOn);
            Assert.Equal(this.DbContext.Materials.Skip(skipCount).FirstOrDefault().Category, result.Category);
            Assert.Equal(this.DbContext.Materials.Skip(skipCount).FirstOrDefault().AuthorId, result.AuthorId);
            Assert.Equal(this.DbContext.Materials.Skip(skipCount).FirstOrDefault().FilesUrls, result.FilesUrls);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetByIdShouldThrowExceptionTest(int skipCount)
        {
            Assert.Throws<NullReferenceException>(() => this.MaterialsServiceMock.GetById(this.DbContext.Materials
                .Skip(this.DbContext.Materials.Count() + skipCount).FirstOrDefault().Id));
        }

       // [Theory]
       // [InlineData(0)]
       // [InlineData(1)]
       // [InlineData(2)]
       // public void DeleteMaterialFilesTest(int skipCount)
       // {
       //     ;
       //     var result = this.MaterialsServiceMock.DelateMaterialFiles(this.DbContext.Materials.Skip(skipCount).FirstOrDefault().Id);
       //
       //     var expected = 0;
       //
       //     Assert.Equal(expected, this.DbContext.Materials.Skip(skipCount).FirstOrDefault().FilesUrls.Count);
       //
       //     this.DbContext.Materials.Skip(skipCount).FirstOrDefault().FilesUrls = this.Files;
       // }

    }
}
