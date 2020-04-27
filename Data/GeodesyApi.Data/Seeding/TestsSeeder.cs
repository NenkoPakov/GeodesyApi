using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
    public class TestsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Tests.Any())
            {
                return;
            }

            var random = new Random();

            var tests = new List<Test>();

            for (int i = 0; i < 10; i++)
            {
                var questionsForCurrentTest = new List<Question>();

                var test = new Test
                {
                    Title = "Описателно заглавие на теста.",
                    Subject = (TestSubjectType)random.Next(1, 4),
                };



                for (int j = 0; j < 10; j++)
                {
                    var questions = dbContext.Questions
                        .Where(q => q.TestId == null)
                        .Skip(i*10)
                        .Take(10)
                        .ToList();

                    foreach (var question in questions)
                    {
                        question.TestId = test.Id;
                    }

                    questionsForCurrentTest.AddRange(questions);
                }

                test.Questions = questionsForCurrentTest;

                tests.Add(test);
            }

            dbContext.Tests.AddRange(tests);
        }
    }
}
