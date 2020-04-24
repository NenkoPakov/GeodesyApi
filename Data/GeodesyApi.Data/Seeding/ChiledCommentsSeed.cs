using GeodesyApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
    public class ChiledCommentsSeed : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Comments.Count()>50)
            {
                return;
            }

            var contents = new[]
{
                "От камарата отбелязват, че очакват активен диалог с АГКК и участие в необходимите изменения на нормативната уредба. Става дума за следните документи",
                "Ok",
                "Мерси",
                "От АГФ приветстват редица досегашни практики на агенцията в критерия за оценките на обществените поръчки. Въпреки това обаче асоциацията отбелязва и моменти, които са спорни. ",
            };

            var childComments = new List<Comment>();
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                var authorId = dbContext.ApplicationUsers
                           .Select(u => u.Id)
                           .Skip(random.Next(0, dbContext.ApplicationUsers.Count() - 1))
                           .FirstOrDefault();

                int newsId = dbContext.News
                           .Select(u => u.Id)
                           .Skip(random.Next(0, dbContext.News.Count() - 1))
                         .FirstOrDefault();

                while (dbContext.Comments.Where(x => x.NewsId == newsId).FirstOrDefault() == null)
                {
                    newsId = dbContext.News
                           .Select(u => u.Id)
                           .Skip(random.Next(0, dbContext.News.Count() - 1))
                         .FirstOrDefault();
                }


                var parentId = dbContext.Comments
                           .Where(x => x.NewsId == newsId)
                           .Select(u => u.Id)
                           .Skip(random.Next(0, dbContext.Comments
                                                .Where(x => x.NewsId == newsId).Count() - 1))
                           .FirstOrDefault();


                var comment = new Comment
                {
                    Content = contents[random.Next(0, contents.Count())],
                    UserId = authorId,
                    NewsId = newsId,
                    ParentId = parentId
                };

                childComments.Add(comment);
            }

            await dbContext.Comments.AddRangeAsync(childComments);
        }
    }
}
