using CharityManager.API.Data;
using CharityManager.API.Model;
using Microsoft.EntityFrameworkCore;

namespace CharityManager.API.Services
{
    public class AuthService(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<User?> ValidateUser(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return null;

            // Verify the password using bcrypt
            if (!PasswordHasher.VerifyPassword(password, user.PasswordHash))
                return null;

            return user;
        }
    }
}
