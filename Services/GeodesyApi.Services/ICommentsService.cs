using GeodesyApi.Data.Models;
using GeodesyApi.Web.ViewModels.Comments;
using GeodesyApi.Web.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public interface ICommentsService
    {
        Task Create(CommentViewModel input, ApplicationUser user);

        bool CanCreate(string userId);
    }
}
