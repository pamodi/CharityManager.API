using CharityManager.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace CharityManager.API.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
