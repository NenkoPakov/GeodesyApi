using GeodesyApi.Common;
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

            foreach (string file in Directory.EnumerateFiles(GlobalConstants.FilesFolderPath))
            {
                var contents = await File.ReadAllBytesAsync(file);
                


            }

            //var materials = new List<>
        }
    }
}
