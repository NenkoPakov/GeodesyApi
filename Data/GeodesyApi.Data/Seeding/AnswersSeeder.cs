using GeodesyApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
    public class AnswersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Answers.Any())
            {
                return;
            }

            var random = new Random();

            var answerTexts = new[]
            {
                new Answer()
                {
                    AnswerText = "Отговор А",
                },
                new Answer()
                {
                    AnswerText = "Отговор Б",
                },
                new Answer()
                {
                    AnswerText = "Отговор В",
                },
                new Answer()
                {
                    AnswerText = "Отговор Г",
                },
            };

            var questions = dbContext.Questions
                .ToList();
            var answers = new List<Answer>();

            foreach (var question in questions)
            {
                var randomCorrectAnswer = random.Next(0, 4);

                var letter = this.RandomString(randomCorrectAnswer);

                answerTexts[randomCorrectAnswer].IsCorrect = true;

                question.Answers = answerTexts;

                foreach (var answer in question.Answers)
                {
                    answer.Id = question.Id;
                }

                answerTexts[randomCorrectAnswer].IsCorrect = false;

                questions.Add(question);
                answers.AddRange(question.Answers);
            }

            await dbContext.Answers.AddRangeAsync(answers);
        }

        public char RandomString(int index)
        {
            var random = new Random();
            const string chars = "АБВГ";

            return chars[index];
        }
    }
}
