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

            var title = "Equal title for each material!";
            var description = "Dispatched entreaties boisterous say why stimulated. Certain forbade picture now prevent carried she get see sitting. Up twenty limits as months. Inhabit so perhaps of in to certain. Sex excuse chatty was seemed warmth. Nay add far few immediate sweetness earnestly dejection. ";
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
