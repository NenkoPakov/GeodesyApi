using CloudinaryDotNet;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.Materials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = Common.GlobalConstants.GeodesyApiAdminRoleName)]
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

        [Route("Admin/Materials/All/{page?}")]
        public IActionResult GetMaterials(int page = 1)
        {
            var materials = this.MaterialsService.GetMaterials(MaterialsPerPage, (page - 1) * MaterialsPerPage);

            if (materials.Materials.Count == 0)
            {
                return this.BadRequest();
            }

            var count = this.MaterialsService.GetCount();

            materials.PagesCount = (int)Math.Ceiling((double)count / MaterialsPerPage);

            if (materials.PagesCount == 0)
            {
                materials.PagesCount = 1;
            }

            materials.CurrentPage = page;

            if (materials.CurrentPage > materials.PagesCount)
            {
                return this.BadRequest();
            }

            return this.View("All", materials);
        }

        [Route("Admin/Materials/{category}/{page?}")]
        public IActionResult GetByCategory(MaterialsType? category, int page = 1)
        {
            if (category == null)
            {
                return this.NotFound();
            }

            var materials = this.MaterialsService.GetByCategory(category, MaterialsPerPage, (page - 1) * MaterialsPerPage);

            var count = this.MaterialsService.GetCount(category);

            materials.PagesCount = (int)Math.Ceiling((double)count / MaterialsPerPage);

            if (materials.PagesCount == 0)
            {
                materials.PagesCount = 1;
            }

            materials.CurrentPage = page;

            if (materials.CurrentPage > materials.PagesCount)
            {
                return this.BadRequest();
            }

            return this.View("All", materials);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var material = this.MaterialsService.GetById(id);

            if (material == null)
            {
                return this.BadRequest();
            }

            var deletedNews = await this.MaterialsService.DeleteAsync(id);

            return this.RedirectToAction("GetMaterials");
        }

    }
}
