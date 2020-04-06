﻿using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.Comments;
using GeodesyApi.Web.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task Create(CommentViewModel input, ApplicationUser user)
        {
            var comment = AutoMapperConfig.MapperInstance.Map<Comment>(input);
            comment.User = user;
            comment.UserId = user.Id;

            await this.CommentsRepository.AddAsync(comment);
            await this.CommentsRepository.SaveChangesAsync();
        }
    }
}
