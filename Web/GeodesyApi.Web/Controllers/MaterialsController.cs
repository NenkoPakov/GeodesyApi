using CloudinaryDotNet;
using GeodesyApi.Common.CloudinaryHelper;
using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Services;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.Materials;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Controllers
{
    public class MaterialsController : BaseController
    {
        public MaterialsController(UserManager<ApplicationUser> userManager, IMaterialsService materialsService)
        {
            this.UserManager = userManager;
            this.MaterialsService = materialsService;
        }

        public UserManager<ApplicationUser> UserManager { get; }
        public IMaterialsService MaterialsService { get; }

        public Cloudinary Cloudinary { get; }

        public async Task<IActionResult> All()
        {
            var allMaterials = this.MaterialsService.GetAll();

            return this.View(allMaterials);
        }

        public IActionResult Upload()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(MaterialUploadViewModel input)
        {
            var user = await this.UserManager.GetUserAsync(this.User);

             var result = await MaterialsService.UploadAsync(input, user.Id);

            //var materialsView = result

            return this.RedirectToAction("All");
        }

    }
}
