using CloudinaryDotNet;
using GeodesyApi.Data;
using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Repositories;
using GeodesyApi.Services.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GeodesyApi.Services.Data.Tests
{
    public abstract class BaseServiceTests : IDisposable
    {
        protected BaseServiceTests()
        {
            var services = this.SetServices();

            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        protected IServiceProvider ServiceProvider { get; set; }
        
        protected ApplicationDbContext DbContext { get; set; }

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(
                opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services
                    .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 5;
                        options.SignIn.RequireConfirmedAccount = true;
                    })
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            var cloudinaryAccount = new CloudinaryDotNet.Account("dv3tfjvk0", "834565789315234", "fh3CxN8m5yoWHhCuxfl6xQJ50hQ");
            var cloudinary = new Cloudinary(cloudinaryAccount);
            services.AddSingleton(cloudinary);

            // Application services
            services.AddTransient<GeodesyApi.Services.Messaging.IEmailSender, SendGridEmailSender>(provider =>
                                                             new SendGridEmailSender(/*this.Configuration["SendGridApiKey"]*/));
            services.AddTransient<GeodesyApi.Services.Messaging.IEmailSender>(x => new SendGridEmailSender(/*this.Configuration["SendGridApiKey"]*/));
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IMaterialsService, MaterialsService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>(c => new CloudinaryService(cloudinary));
            services.AddTransient<IProjectsService, ProjectsService>();
            services.AddTransient<IContactsService, ContactsService>();


            // Cloudinary Setup


            var context = new DefaultHttpContext();
            services.AddSingleton<IHttpContextAccessor>(new HttpContextAccessor { HttpContext = context });

            return services;
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            this.SetServices();
        }
    }
}
