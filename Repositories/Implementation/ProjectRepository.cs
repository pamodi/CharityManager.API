using CharityManager.API.Data;
using CharityManager.API.Entity;
using CharityManager.API.Model;
using CharityManager.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CharityManager.API.Repositories.Implementation
{
    public class ProjectRepository(AppDbContext context) : BaseRepo(context), IProjectRepository
    {
        public async Task<IEnumerable<ProjectModel>> GetProjectsAsync()
        {
            return await _context.Projects
                                 .Where(u => u.DeletedAt == null)
                                 .Select(q => new ProjectModel()
                                 {
                                     Id = q.Id,
                                     Name = q.Name,
                                     Description = q.Description,
                                     Status = q.Status,
                                     Category = q.Category,
                                     Coordinator = q.Coordinator,
                                     CreatedAt = q.CreatedAt,
                                     UpdatedAt = q.UpdatedAt
                                 }).ToListAsync();
        }

        public async Task<IEnumerable<ProjectModel>> GetPendingProjectsAsync()
        {
            return await _context.Projects
                                 .Where(u => u.Status != "Completed" && u.DeletedAt == null)
                                 .Select(q => new ProjectModel()
                                 {
                                     Id = q.Id,
                                     Name = q.Name,
                                     Description = q.Description,
                                     Status = q.Status,
                                     Category = q.Category,
                                     Coordinator = q.Coordinator,
                                     CreatedAt = q.CreatedAt,
                                     UpdatedAt = q.UpdatedAt
                                 }).ToListAsync();
        }

        public ProjectModel GetProjectDetails(int projectId)
        {
            var project = _context.Projects.FirstOrDefault(q => q.Id == projectId && q.DeletedAt == null) ?? throw new InvalidOperationException("Project not found.");

            return new ProjectModel()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Status = project.Status,
                Category = project.Category,
                Coordinator = project.Coordinator,
                CreatedAt = project.CreatedAt,
                UpdatedAt = project.UpdatedAt
            };
        }
    }
}
