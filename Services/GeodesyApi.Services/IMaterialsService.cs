using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.Materials;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeodesyApi.Services
{
    public interface IMaterialsService
    {
        //Task<IDeletableEntityRepository<Material>> UploadAsync(string title, int category, ICollection<IFormFile> files, string userId);
        Task<IDeletableEntityRepository<Material>> UploadAsync(MaterialUploadViewModel input, string userId);

        GetAllMaterialsViewModel GetAll();
    }
}
