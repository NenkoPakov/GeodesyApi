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
        public NewsService(IDeletableEntityRepository<News> newsRepository, IDeletableEntityRepository<ApplicationUser> userRepository, ICommentsService commentsService,ICloudinaryService cloudinary)
        {
            this.Cloudinary = cloudinary;
            this.NewsRepository = newsRepository;
            this.UserRepository = userRepository;
            this.CommentsService = commentsService;
        }

        public ICloudinaryService Cloudinary { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public IDeletableEntityRepository<News> NewsRepository { get; }

        public IDeletableEntityRepository<ApplicationUser> UserRepository { get; }
        public ICommentsService CommentsService { get; }

        public async Task<News> CreateNews(CreateNewsViewModel input, ApplicationUser user)
        {
            var uploadResult = await this.Cloudinary.UploadAsync(input.Image);

            var news = AutoMapperConfig.MapperInstance.Map<News>(input);

            news.ImageUrl = uploadResult;
            news.User = user;
            news.UserId = user.Id;
            news.User.News.Add(news);

            await this.NewsRepository.AddAsync(news);

            await this.NewsRepository.SaveChangesAsync();
            await this.UserRepository.SaveChangesAsync();

            return news;
        }

        public News GetById(int newsId)
        {
            var news = this.NewsRepository.All()
                .Where(n => n.Id == newsId)
                .FirstOrDefault();

            news.Comments=this.CommentsService.GetAllByNewsId(newsId);

            return news;
        }

        public GetNewsCollectionViewModel GetNews(int? take = null, int skip = 0)
        {
            var newsViewModel = new GetNewsCollectionViewModel();

            var query = this.GetAll()
                .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            var news = query.To<GetNewsViewModel>().ToList();

            newsViewModel.News = news;

            return newsViewModel;
        }


        public GetNewsCollectionViewModel GetByCategory(NewsGroupType? newsGroup = null, int? take = null, int skip = 0)
        {
            var newsViewModel = new GetNewsCollectionViewModel();

            var query = this.GetByGroup(newsGroup)
                .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            var news = query.To<GetNewsViewModel>().ToList();

            newsViewModel.News = news;

            return newsViewModel;
        }

        private IQueryable<News> GetByGroup(NewsGroupType? newsGroup)
        {
            return this.NewsRepository.All()
                .Where(c => c.Group == newsGroup)
                .OrderByDescending(x => x.CreatedOn);
        }

        private IQueryable<News> GetAll()
        {
            return this.NewsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn);
        }



        public int GetCount(NewsGroupType? category = null)
        {
            if (category != null)
            {
                return this.GetByGroup(category)
                    .Count();
            }

            return this.GetAll().Count();
        }

        public GetNewsCollectionViewModel GetLastNews()
        {
            var countOfNewsAtHomePage = 4;

            var newsViewModel = new GetNewsCollectionViewModel();

            var news = this.GetAll()
                .Take(countOfNewsAtHomePage)
                .To<GetNewsViewModel>()
                .ToList();

            newsViewModel.News = news;

            return newsViewModel;
        }

        public async Task<IDeletableEntityRepository<News>> EditAsync(EditNewsViewModel input, ApplicationUser user)
        {
            var uploadResult = await this.Cloudinary.UploadAsync(input.Image);

            var news = AutoMapperConfig.MapperInstance.Map<News>(input);

            news.ImageUrl = uploadResult;
            news.User = user;
            news.UserId = user.Id;

            this.NewsRepository.Update(news);

            await this.NewsRepository.SaveChangesAsync();
            await this.UserRepository.SaveChangesAsync();

            return this.NewsRepository;
        }

        public async Task<News> DeleteAsync(int newsId)
        {
            var news = this.GetById(newsId);

            this.NewsRepository.Delete(news);
            await this.NewsRepository.SaveChangesAsync();

            return news;
        }
    }
}
