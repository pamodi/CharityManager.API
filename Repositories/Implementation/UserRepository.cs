using CharityManager.API.Data;
using CharityManager.API.Model;
using CharityManager.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CharityManager.API.Repositories.Implementation
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<UserModel>> GetUsersByRoleAsync(string role)
        {
            return await _context.Users
                                 .Where(u => u.Role == role)
                                 .Select(q => new UserModel()
                                 {
                                     Id = q.Id,
                                     Email = q.Email,
                                     DisplayName = $"{q.FirstName} {q.LastName}",
                                     FirstName = q.FirstName,
                                     LastName = q.LastName,
                                     PhoneNumber = q.PhoneNumber,
                                     Role = q.Role,
                                     WhatsApp = q.WhatsApp,
                                     Address = q.Address,
                                     Guid = q.Guid,
                                     Description = q.Description,
                                     CreatedAt = q.CreatedAt,
                                     UpdatedAt = q.UpdatedAt,
                                     DeletedAt = q.DeletedAt
                                 }).ToListAsync();
        }
    }
}
