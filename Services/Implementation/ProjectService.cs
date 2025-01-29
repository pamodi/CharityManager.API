using CharityManager.API.Model;
using CharityManager.API.Repositories.Interface;
using CharityManager.API.Services.Interface;

namespace CharityManager.API.Services.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectModel>> GetProjectsAsync()
        {
            return await _projectRepository.GetProjectsAsync();
        }

        public async Task<IEnumerable<ProjectModel>> GetPendingProjectsAsync()
        {
            return await _projectRepository.GetPendingProjectsAsync();
        }
    }
}
