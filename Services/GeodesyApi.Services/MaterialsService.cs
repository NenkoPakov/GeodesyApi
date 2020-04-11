using CloudinaryDotNet;
using GeodesyApi.Common.CloudinaryHelper;
using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using GeodesyApi.Services.Mapping;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeodesyApi.Web.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using GeodesyApi.Web.ViewModels.Materials;

namespace GeodesyApi.Services
{
    public class MaterialsService : IMaterialsService
    {

        public MaterialsService(IDeletableEntityRepository<Material> materialsRepository, Cloudinary cloudinary)
        {
            this.Cloudinary = cloudinary;
            this.MaterialsRepository = materialsRepository;
        }

        public Cloudinary Cloudinary { get; }

        public UserManager<string> UserManager { get; }

        public IDeletableEntityRepository<Material> MaterialsRepository { get; }

        public GetAllMaterialsViewModel GetMaterials(int? take = null, int skip = 0)
        {
            var viewModel = new GetAllMaterialsViewModel();

            var query = this.GetAll()
                .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            var materials = query.To<GetMaterialViewModel>().ToList();

            viewModel.Materials = materials;

            return viewModel;
        }


        public GetAllMaterialsViewModel GetByCategory(MaterialsType? materialsCategory = null, int? take = null, int skip = 0)
        {
            var viewModel = new GetAllMaterialsViewModel();

            var query = this.GetByCategoty(materialsCategory)
                .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            var materials = query.To<GetMaterialViewModel>().ToList();

            viewModel.Materials = materials;

            return viewModel;
        }

        public int GetCount(MaterialsType? category=null)
        {
            if (category!=null)
            {
                return this.GetByCategoty(category)
                    .Count();
            }

            return this.GetAll().Count();
        }

        private IQueryable<Material> GetByCategoty(MaterialsType? materialsCategoty)
        {
            return this.MaterialsRepository.All()
                .Where(c => c.Category == materialsCategoty)
                .OrderByDescending(x => x.CreatedOn);
        }

        private IQueryable<Material> GetAll()
        {
            return this.MaterialsRepository.All()
                .OrderByDescending(x => x.CreatedOn);
        }

        public async Task<IDeletableEntityRepository<Material>> UploadAsync(MaterialUploadViewModel input, string userId)
        {
            var uploadResult = await CloudinaryExtension.UploadMultipleAsync(this.Cloudinary, input.Files);

            foreach (var file in uploadResult)
            {
                var material = AutoMapperConfig.MapperInstance.Map<Material>(input);

                //var material = new Material()
                //{
                //    AuthorId = userId,
                //    Category = (MaterialsType)category,
                //    Title = title,
                //    FileUrl = file.Uri.AbsoluteUri,
                //};

                material.AuthorId = userId;
                material.FileUrl = file.Uri.AbsoluteUri;

                await this.MaterialsRepository.AddAsync(material);
            }

            await this.MaterialsRepository.SaveChangesAsync();

            return this.MaterialsRepository;
        }
    }
}
