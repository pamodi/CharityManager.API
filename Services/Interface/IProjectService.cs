using CharityManager.API.Model;

namespace CharityManager.API.Services.Interface
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectModel>> GetProjectsAsync();
        Task<IEnumerable<ProjectModel>> GetPendingProjectsAsync();
        ProjectModel GetProjectDetails(int projectId);
        ProjectCreateResponse CreateProject(ProjectCreateRequest projectCreateRequest);
        void UpdateProject(int projectId, ProjectUpdateRequest projectUpdateRequest);
        void DeleteProject(int projectId);
    }
}
