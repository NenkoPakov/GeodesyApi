﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.Materials;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeodesyApi.Services
{
    public interface IMaterialsService
    {
        Task<IDeletableEntityRepository<Material>> UploadAsync(MaterialUploadViewModel input, ApplicationUser user);

        int GetCount(MaterialsType? category = null);

        GetAllMaterialsViewModel GetMaterials(int? take = null, int skip = 0);

        GetAllMaterialsViewModel GetByCategory(MaterialsType? materialsCategory = null, int? take = null, int skip = 0);

        Material GetById(int materialId);

        Task DelateMaterialFiles(int materialId);

        Task<Material> DeleteAsync(int materialId);

        Task<IDeletableEntityRepository<Material>> EditAsync(MaterialEditViewModel input, ApplicationUser user);
    }
}
