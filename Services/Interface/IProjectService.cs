using CharityManager.API.Model;

namespace CharityManager.API.Services.Interface
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectModel>> GetProjectsAsync();
        Task<IEnumerable<ProjectModel>> GetPendingProjectsAsync();
    }
}
