using GeodesyApi.Common;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
    public class MaterialsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Materials.Any())
            {
                return;
            }

            var title = "Заглавие за всички материали!";
            var description = "В писмо до директора на АГКК инж. Михаил Киров, КИГ предложиха в състава на комисията за разглеждане на обществените поръчки в областта на геодезията и кадастъра да бъде включен като наблюдаващ член и представител на НПО: адв. Лъчезар Тодоров от Софийска адвокатска колегия. ";
            var random = new Random();
            var materials = new List<Material>();

            for (int i = 0; i < 20; i++)
            {
                var authorId = dbContext.ApplicationUsers
                          .Select(u => u.Id)
                          .Skip(random.Next(0, 2))
                          .FirstOrDefault();

                var material = new Material
                {
                    AuthorId = authorId,
                    Category = (MaterialsType)random.Next(1, 9),
                    Description = description,
                    Title = title,
                    FilesUrls = dbContext.MaterialsFiles
                    .Where(f => f.UserId == authorId)
                              .ToList(),
                };

                materials.Add(material);
            }

            dbContext.AddRange(materials);
        }
    }
}
