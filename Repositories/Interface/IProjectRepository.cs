﻿using CharityManager.API.Model;

namespace CharityManager.API.Repositories.Interface
{
    public interface IProjectRepository : IRepo
    {
        Task<IEnumerable<ProjectModel>> GetProjectsAsync();
        Task<IEnumerable<ProjectModel>> GetPendingProjectsAsync();
        ProjectModel GetProjectDetails(int projectId);
        ProjectCreateResponse CreateProject(ProjectCreateRequest projectCreateRequest);
        void UpdateProject(int projectId, ProjectUpdateRequest projectUpdateRequest);
        void DeleteProject(int projectId);
    }
}
