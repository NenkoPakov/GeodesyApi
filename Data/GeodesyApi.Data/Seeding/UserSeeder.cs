using GeodesyApi.Common;
using GeodesyApi.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Data.Seeding
{
    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Random random = new System.Random();
            var phoneNumberFirstDigits = "088";
            var profilePicture = "https://res.cloudinary.com/dv3tfjvk0/image/upload/v1587671638/defaultProfilePicture_ohsear.png";
            var userManager = serviceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            if (dbContext
                .ApplicationUsers
                .Any())
            {
                return;
            }

            var user = new ApplicationUser
            {
                UserName = "admin",
                Email = "geodesyapi@abv.bg",
                FirstName = "admin",
                LastName = "admin",
                PhoneNumber = "0888888888",
                PictureUrl= profilePicture,
                EmailConfirmed=true,
            };

            var adminPassword = "admin123";

            var result = await userManager.CreateAsync(user, adminPassword);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            }

            for (int i = 1; i <= 2; i++)
            {
                string randomDigits = default;
                for (int n = 0; n < 7; n++)
                {
                    randomDigits += random.Next(0, 9);
                }

                var phoneNumber = phoneNumberFirstDigits + randomDigits;
                var facultyNumber = int.Parse(randomDigits.Substring(randomDigits.Length - 5, 4));

                var regularUser = new ApplicationUser
                {
                    UserName = $"regular{i}",
                    Email = $"geodesyapi_regular{i}@abv.bg",
                    FirstName = $"Regular{i}",
                    LastName = $"Regular{i}",
                    FacultyNumber = facultyNumber,
                    PhoneNumber = phoneNumber,
                    PictureUrl = profilePicture,
                    EmailConfirmed = true,
                };

                var userPassword = $"regular{i}";
                await userManager.CreateAsync(regularUser, userPassword);
            }
        }
    }
}
