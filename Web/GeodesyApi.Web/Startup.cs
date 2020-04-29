namespace GeodesyApi.Web
{
    using System.Reflection;
    using CloudinaryDotNet;
    using GeodesyApi.Data;
    using GeodesyApi.Data.Common;
    using GeodesyApi.Data.Common.Repositories;
    using GeodesyApi.Data.Models;
    using GeodesyApi.Data.Repositories;
    using GeodesyApi.Data.Seeding;
    using GeodesyApi.Services.Data;
    using GeodesyApi.Services.Mapping;
    using GeodesyApi.Services.Messaging;
    using GeodesyApi.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using CloudinaryDotNet;
    using System;
    using System.IO;
    using GeodesyApi.Services;
    using GeodesyApi.Web.Middleware;
    using Microsoft.AspNetCore.Mvc;

    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(configure =>
            configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)

                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(this.Configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            Environment.SetEnvironmentVariable("SEND_GRID", this.Configuration["Cloudinary:ApiName"]);

            // Cloudinary
            Account account = new Account(
                this.Configuration["Cloudinary:ApiName"],
                this.Configuration["Cloudinary:ApiKey"],
                this.Configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinary = new Cloudinary(account);

            services.AddSingleton(cloudinary);

            // Application services
            services.AddTransient<GeodesyApi.Services.Messaging.IEmailSender, SendGridEmailSender>(provider =>
                                                                     new SendGridEmailSender());
            services.AddTransient<GeodesyApi.Services.Messaging.IEmailSender>(x => new SendGridEmailSender());
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IMaterialsService, MaterialsService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>(c => new CloudinaryService(cloudinary));
            services.AddTransient<IProjectsService, ProjectsService>();
            services.AddTransient<IContactsService, ContactsService>();
            services.AddTransient<ITestsService, TestsService>();
            services.AddTransient<IQuestionsService, QuestionsService>();
            services.AddTransient<IAnswersService, AnswersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(
                        "AreaNumberOfMaterialsPages",
                        "{area:exists}/materials/{category}/{page}",
                        new { controller = "Materials", action = "GetMaterials", page = 1 });
                    endpoints.MapControllerRoute(
    "NumberOfMaterialsPages",
    "materials/{category}/{page}",
    new { controller = "Materials", action = "GetMaterials", page = 1 });
                    endpoints.MapControllerRoute(
    "AreaNumberOfMaterialsPages",
    "{area:exists}/materials/All/{page}",
    new { controller = "Materials", action = "GetMaterials", page = 1 });
                    endpoints.MapControllerRoute(
                        "NumberOfMaterialsPages",
                        "materials/All/{page}",
                        new { controller = "Materials", action = "GetMaterials", page = 1 });
                    endpoints.MapControllerRoute(
    "AreaNumberOfNewsPages",
    "{area:exists}/news/{category}/{page}",
    new { controller = "News", action = "GetNews", page = 1 });
                    endpoints.MapControllerRoute(
                        "NumberOfNewsPages",
                        "news/{category}/{page}",
                        new { controller = "News", action = "GetNews", page = 1 });
                    endpoints.MapControllerRoute(
    "AreaNumberOfNewsPages",
    "{area:exists}/news/All/{page}",
    new { controller = "News", action = "GetNews", page = 1 });
                    endpoints.MapControllerRoute(
                        "NumberOfNewsPages",
                        "news/All/{page}",
                        new { controller = "News", action = "GetNews", page = 1 });
                    endpoints.MapControllerRoute(
                        "areaRoute",
                        "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute(
                        "default",
                        "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
        }
    }
}
