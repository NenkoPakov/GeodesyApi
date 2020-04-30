using GeodesyApi.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GeodesyApi.Services.Data.Tests
{
    public class CommentsServiceTest : BaseServiceTests
    {
        public CommentsServiceTest()
        {
            List<ApplicationUser> users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    FirstName = "testUser",
                    LastName = "testUser",
                    Id = "1-1-1-1",
                    Email = "test@test.test",
                },
                new ApplicationUser
                {
                    FirstName = "testUser2",
                    LastName = "testUser2",
                    Id = "1-1-1-2",
                    Email = "test@test2.test",
                },
                new ApplicationUser
                {
                    FirstName = "testUser3",
                    LastName = "testUser3",
                    Id = "1-1-1-3",
                    Email = "test@test3.test",
                },
            };

            DbContext.Users.AddRange(users);
            DbContext.SaveChanges();
        }

        private ICommentsService CommentsServiceMock => this.ServiceProvider.GetRequiredService<ICommentsService>();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void CanCreateTest(int skip)
        {
            var user = this.DbContext.Users.Skip(skip).FirstOrDefault();

            var result = this.CommentsServiceMock.CanCreate(user.Id);

            var expected = true;

            Assert.Equal(result, expected);
        }
    }
}
