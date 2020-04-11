using CloudinaryDotNet;
using GeodesyApi.Common.CloudinaryHelper;
using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
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
        private const int MaterialsPerPage = 3;

        public MaterialsController(UserManager<ApplicationUser> userManager, IMaterialsService materialsService)
        {
            this.UserManager = userManager;
            this.MaterialsService = materialsService;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public IMaterialsService MaterialsService { get; }

        public Cloudinary Cloudinary { get; }


        [Route("Materials/All/{page?}")]
        public async Task<IActionResult> GetMaterials(int page = 1)
        {
            var materials = this.MaterialsService.GetMaterials(MaterialsPerPage, (page - 1) * MaterialsPerPage);

            var count = this.MaterialsService.GetCount();

            materials.PagesCount = (int)Math.Ceiling((double)count / MaterialsPerPage);

            if (materials.PagesCount == 0)
            {
                materials.PagesCount = 1;
            }

            materials.CurrentPage = page;

            return this.View("All", materials);
        }


        [Route("Materials/{category}/{page?}")]
        public async Task<IActionResult> GetByCategory(MaterialsType? category, int page = 1)
        
        {
            var materials = this.MaterialsService.GetByCategory(category, MaterialsPerPage, (page - 1) * MaterialsPerPage);

            var count = this.MaterialsService.GetCount(category);

            materials.PagesCount = (int)Math.Ceiling((double)count / MaterialsPerPage);

            if (materials.PagesCount == 0)
            {
                materials.PagesCount = 1;
            }

            materials.CurrentPage = page;

            return this.View("All", materials);
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
