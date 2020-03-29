using CloudinaryDotNet;
using GeodesyApi.Common.CloudinaryHelper;
using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.News;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public class NewsService : INewsService
    {
        public NewsService(IDeletableEntityRepository<News> newsRepository, IDeletableEntityRepository<ApplicationUser> userRepository, Cloudinary cloudinary)
        {
            this.Cloudinary = cloudinary;
            this.NewsRepository = newsRepository;
            this.UserRepository = userRepository;
        }

        public Cloudinary Cloudinary { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public IDeletableEntityRepository<News> NewsRepository { get; }

        public IDeletableEntityRepository<ApplicationUser> UserRepository { get; }

        public async Task<News> CreateNews(CreateNewsViewModel input, ApplicationUser user)
        {
            var uploadResult = await CloudinaryExtension.UploadAsync(this.Cloudinary, input.Image);

            var news = AutoMapperConfig.MapperInstance.Map<News>(input);

            //news.ImageUrl = uploadResult.Uri.AbsoluteUri;
            news.ImageUrl = uploadResult.Uri.AbsoluteUri;
            news.User = user;
            news.UserId = user.Id;
            news.User.News.Add(news);

            await this.NewsRepository.AddAsync(news);

            await this.NewsRepository.SaveChangesAsync();
            await this.UserRepository.SaveChangesAsync();

            return news;
        }

        public GetNewsCollectionViewModel GetNews(int? id)
        {
            var getNewsViewModel = new GetNewsCollectionViewModel();

            List<GetNewsViewModel> news;

            if (id == null)
            {
                news = this.NewsRepository.All()
                                .To<GetNewsViewModel>()
                                .ToList();
            }
            else
            {
                news = this.NewsRepository.All()
                .Where(n => (int)n.Category == id)
                .To<GetNewsViewModel>()
                .ToList();
            }

            getNewsViewModel.News = news;

            return getNewsViewModel;
        }
    }
}
