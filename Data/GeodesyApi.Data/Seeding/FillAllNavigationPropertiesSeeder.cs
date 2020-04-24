using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
   public class FillAllNavigationPropertiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            //if (dbContext.ApplicationUsers.Sum(x => x.News.Sum(y=>y.Id))!=0)
            //{
            //    return;
            //}

            foreach (var material in dbContext.Materials)
            {
                material.FilesUrls = dbContext.MaterialsFiles.Where(x => x.MaterialId == material.Id).ToList();
            }

            foreach (var news in dbContext.News)
            {
                news.Comments = dbContext.Comments.Where(x => x.NewsId == news.Id).ToList();
            }

            foreach (var user in dbContext.ApplicationUsers)
            {
                user.Materials = dbContext.Materials.Where(x => x.AuthorId == user.Id).ToList();
                user.Comments = dbContext.Comments.Where(x => x.UserId == user.Id).ToList();
                user.News = dbContext.News.Where(x => x.UserId == user.Id).ToList();
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
