using GeodesyApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
    public class QuestionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Questions.Any())
            {
                return;
            }

            var random = new Random();

            var questionText = "За верен отговор, маркирай отговор ";

            var questions = new List<Question>();
            var answers = new List<Answer>();

            for (int i = 0; i < 100; i++)
            {
                var randomCorrectAnswer = random.Next(0, 4);

                var answerTexts = new List<Answer>
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

                var letter = this.RandomString(randomCorrectAnswer);

                answerTexts[randomCorrectAnswer].IsCorrect = true;

                var question = new Question();
                question.QuestionText = questionText + letter;

                foreach (var answer in answerTexts)
                {
                    answer.QuestionId = question.Id;
                }

                question.Answers = answerTexts;

                answers.AddRange(answerTexts);
                questions.Add(question);
            }

            dbContext.Questions.AddRange(questions);
            dbContext.Answers.AddRange(answers);
        }


        public char RandomString(int index)
        {
            var random = new Random();
            const string chars = "АБВГ";

            return chars[index];
        }
    }
}
