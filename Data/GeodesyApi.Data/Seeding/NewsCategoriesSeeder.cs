using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
    public class NewsCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
       //     if (dbContext.NewsCategories.Any())
       //     {
       //         return;
       //     }
       //
       //     var categories = new List<(string name, string parent)>
       //     {
       //         ("Новини", null),
       //         ("Събития", null),
       //         ("Препоръчано за студенти", null),
       //         ("Заседание на работна група", "Новини"),
       //         ("Конференция", "Новини"),
       //         ("Нови геод. инструменти", "Новини"),
       //         ("Конкурси", "Новини"),
       //         ("Новини", null),
       //     };
       //     foreach (var category in categories)
       //     {
       //         await dbContext.Categories.AddAsync(new Category
       //         {
       //             Name = category.Name,
       //             Description = category.Name,
       //             Title = category.Name,
       //             ImageUrl = category.ImageUrl,
       //         });
       //     }
        }
    }
}
