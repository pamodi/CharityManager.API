using CharityManager.API.Data;
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
    }
}
