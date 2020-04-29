using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public class CommentsService : ICommentsService
    {
        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.CommentsRepository = commentsRepository;
        }

        public IDeletableEntityRepository<Comment> CommentsRepository { get; }

        public bool CanCreate(string userId)
        {
            var currentTime = DateTime.UtcNow;

            var lastPost = this.CommentsRepository.AllWithDeleted()
           .Where(c => c.UserId == userId)
            .OrderByDescending(c => c.CreatedOn)
            .FirstOrDefault();

            if (lastPost == null)
            {
                return true;
            }

            var createdOnTimeOfLastPost = lastPost.CreatedOn;

            if (currentTime.Date == createdOnTimeOfLastPost.Date)
            {
                return (currentTime.TimeOfDay - createdOnTimeOfLastPost.TimeOfDay).TotalMinutes > 2;
            }

            return true;
        }

        public async Task Create(CommentViewModel input, ApplicationUser user)
        {
            var comment = AutoMapperConfig.MapperInstance.Map<Comment>(input);
            comment.User = user;
            comment.UserId = user.Id;

            user.Comments.Add(comment);

            await this.CommentsRepository.AddAsync(comment);
            await this.CommentsRepository.SaveChangesAsync();

            Thread.Sleep(1500);
        }

        public ICollection<Comment> GetAllByNewsId(int newsId)
        {
            var comments = this.CommentsRepository.AllAsNoTracking()
                .Where(x => x.NewsId == newsId).ToList();

            return comments;
        }
    }
}
