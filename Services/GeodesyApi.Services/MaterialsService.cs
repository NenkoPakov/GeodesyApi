﻿using CloudinaryDotNet;
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
        public MaterialsService(IDeletableEntityRepository<Material> materialsRepository, IDeletableEntityRepository<MaterialFiles> materialFilesRepository, ICloudinaryService cloudinary)
        {
            this.Cloudinary = cloudinary;
            this.MaterialsRepository = materialsRepository;
            this.MaterialFilesRepository = materialFilesRepository;
        }

        public ICloudinaryService Cloudinary { get; }

        public UserManager<string> UserManager { get; }

        public IDeletableEntityRepository<Material> MaterialsRepository { get; }

        public IDeletableEntityRepository<MaterialFiles> MaterialFilesRepository { get; }

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

            this.AddMaterialFiles(materials);

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

            this.AddMaterialFiles(materials);

            viewModel.Materials = materials;

            return viewModel;
        }

        public int GetCount(MaterialsType? category = null)
        {
            if (category != null)
            {
                return this.GetByCategoty(category)
                    .Count();
            }

            return this.GetAll().Count();
        }

        public async Task<IDeletableEntityRepository<Material>> UploadAsync(MaterialUploadViewModel input, ApplicationUser user)
        {
            var material = AutoMapperConfig.MapperInstance.Map<Material>(input);

            await this.MaterialsRepository.AddAsync(material);

            material.AuthorId = user.Id;

            var uploadResult = await this.Cloudinary.UploadMultipleAsync(input.Files);
            foreach (var fileUrl in uploadResult)
            {
                var file = new MaterialFiles
                {
                    MaterialId = material.Id,
                    Material = material,
                    UserId = user.Id,
                    FileUrl = fileUrl,
                };

                material.FilesUrls.Add(file);
                await this.MaterialFilesRepository.AddAsync(file);
            }

            await this.MaterialsRepository.SaveChangesAsync();
            await this.MaterialFilesRepository.SaveChangesAsync();
            user.Materials.Add(material);

            return this.MaterialsRepository;
        }

        public Material GetById(int materialId)
        {
            var material = this.MaterialsRepository.All()
                .Where(n => n.Id == materialId)
                .FirstOrDefault();

            return material;
        }

        public async Task<IDeletableEntityRepository<Material>> EditAsync(MaterialEditViewModel input, ApplicationUser user)
        {
            await this.DelateMaterialFiles(input.Id);

            var material = this.GetById(input.Id);
            material.Title = input.Title;
            material.Description = input.SanitizedDescription;

            var uploadResult = await this.Cloudinary.UploadMultipleAsync(input.Files);
            foreach (var fileUrl in uploadResult)
            {
                var file = new MaterialFiles
                {
                    MaterialId = material.Id,
                    Material = material,
                    UserId = user.Id,
                    FileUrl = fileUrl,
                };

                material.FilesUrls.Add(file);
                await this.MaterialFilesRepository.AddAsync(file);
            }

            this.MaterialsRepository.Update(material);
            await this.MaterialsRepository.SaveChangesAsync();
            await this.MaterialFilesRepository.SaveChangesAsync();
            user.Materials.Add(material);

            return this.MaterialsRepository;
        }

        public async Task DelateMaterialFiles(int materialId)
        {
            var materials = this.MaterialFilesRepository
                .All()
                .Where(m => m.MaterialId == materialId);

            foreach (var material in materials)
            {
                this.MaterialFilesRepository.Delete(material);
            }

            await this.MaterialFilesRepository.SaveChangesAsync();
        }



        public async Task<Material> DeleteAsync(int materialId)
        {
            var material = this.MaterialsRepository
                .All()
                .Where(u => u.Id == materialId)
                .FirstOrDefault();

            await this.DelateMaterialFiles(materialId);

            this.MaterialsRepository.Delete(material);

            await this.MaterialsRepository.SaveChangesAsync();

            return material;
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

        private void AddMaterialFiles(ICollection<GetMaterialViewModel> materials)
        {
            foreach (var material in materials)
            {
                material.FilesUrlsFileUrl = this.MaterialFilesRepository
                    .AllAsNoTracking()
                    .Where(x => x.MaterialId == material.Id)
                    .Select(x => x.FileUrl).ToList();
            }
        }
    }
}
