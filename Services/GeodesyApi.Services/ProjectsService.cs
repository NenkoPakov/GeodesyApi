using GeodesyApi.Data.Common.Repositories;
using GeodesyApi.Data.Models;
using GeodesyApi.Services.Mapping;
using GeodesyApi.Web.ViewModels.Projects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public class ProjectsService:IProjectsService
    {
        public ProjectsService(IDeletableEntityRepository<Project> projectsRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.ProjectsRepository = projectsRepository;
            this.UserRepository = userRepository;
        }

        public IDeletableEntityRepository<Project> ProjectsRepository { get; }
        public IDeletableEntityRepository<ApplicationUser> UserRepository { get; }

        public async Task<Project> CreateProject(CreateProjectViewModel input, ApplicationUser user)
        {
            input.Author = user;
            input.AuthorId = user.Id;

            var project = AutoMapperConfig.MapperInstance.Map<Project>(input);

            project.Author.Projects.Add(project);

            await this.ProjectsRepository.AddAsync(project);

            await this.ProjectsRepository.SaveChangesAsync();
            await this.UserRepository.SaveChangesAsync();

            return project;
        }
    }
}
