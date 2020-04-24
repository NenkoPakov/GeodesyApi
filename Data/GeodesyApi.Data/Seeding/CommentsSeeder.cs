using GeodesyApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
    class CommentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Comments.Any())
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

            var mainComments = new List<Comment>();
            var childComments = new List<Comment>();
            var random = new Random();



            for (int i = 0; i < 50; i++)
            {
                var authorId = dbContext.ApplicationUsers
                            .Select(u => u.Id)
                            .Skip(random.Next(0, 2))
                            .FirstOrDefault();

                var comment = new Comment
                {
                    Content = contents[random.Next(0, contents.Count())],
                    UserId = authorId,
                    NewsId = dbContext.News
                             .Select(u => u.Id)
                             .Skip(random.Next(0, dbContext.News.Count() - 1))
                           .FirstOrDefault(),
                };

                mainComments.Add(comment);
            }

            


            dbContext.Comments.AddRange(mainComments);
        }
    }
}
