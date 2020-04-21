using GeodesyApi.Data.Models;
using GeodesyApi.Web.ViewModels.Projects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeodesyApi.Services
{
    public interface IProjectsService
    {
        Task<Project> CreateProject(CreateProjectViewModel input, ApplicationUser user);
    }
}
