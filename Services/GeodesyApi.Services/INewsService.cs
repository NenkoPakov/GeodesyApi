using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Data.Models.Enums;
using GeodesyApi.Web.ViewModels;
using GeodesyApi.Web.ViewModels.News;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public interface INewsService
    {
        Task<News> CreateNews(CreateNewsViewModel input, ApplicationUser user);

        GetNewsCollectionViewModel GetNews(int? id);

        int GetCount();

        //GetNewsCollectionViewModel GetAll(int? take = null, int skip = 0);

        GetNewsCollectionViewModel GetNews(NewsGroupType? newsGroup = null, int? take = null, int skip = 0);
    }
}
