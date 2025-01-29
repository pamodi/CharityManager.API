using CharityManager.API.Model;

namespace CharityManager.API.Repositories.Interface
{
    public interface IProjectRepository : IRepo
    {
        Task<IEnumerable<ProjectModel>> GetProjectsAsync();
        Task<IEnumerable<ProjectModel>> GetPendingProjectsAsync();
    }
}
