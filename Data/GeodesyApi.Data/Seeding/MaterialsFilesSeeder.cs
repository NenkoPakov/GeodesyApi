using GeodesyApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
    public class MaterialsFilesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var random = new Random();
            var materials = new[]
            {
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587642825/d3iccpxwcr2hfx4ttane.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587642824/dsqdz6ptypzl0wkkdsih.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587642823/xrjbzo5lcnmj4u8jyret.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587635757/rehzkxgurxbnf1eqwpas.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587626688/wfcfg2scoqjtkxf9acil.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587625891/xhdvk1gkhcsaxmzzarhq.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587599870/xtyt8g2i4lbyhpevfkkt.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587598184/ch6xyrddkfgcgyvrlvbb.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587598066/dbyewp7gk3reqr8ncegm.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587598063/bso0kjtqm6wybwea2ucs.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1584389192/dechev.pdf",
                "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587625868/q4ebqh1q9ivvhm3vdwbf.pdf",
            };

            var materialsFiles = new List<MaterialFiles>();

            if (dbContext.MaterialsFiles.Any())
            {
                return;
            }


            for (int i = 0; i < 150; i++)
            {
                var materialFile = new MaterialFiles
                {

                    FileUrl = materials[random.Next(0, materials.Count())],
                    MaterialId = dbContext.Materials.Skip(random.Next(0, dbContext.Materials.Count() - 1))
                           .FirstOrDefault().Id,
                    UserId = dbContext.ApplicationUsers.Skip(random.Next(0, dbContext.ApplicationUsers.Count() - 1))
                           .FirstOrDefault().Id,
                };

                materialsFiles.Add(materialFile);
            }

            dbContext.MaterialsFiles.AddRange(materialsFiles);
        }
    }
}
