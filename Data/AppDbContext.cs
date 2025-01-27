using CharityManager.API.Entity;
using CharityManager.API.Services;
using Microsoft.EntityFrameworkCore;

namespace CharityManager.API.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial users with hashed passwords
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Username = "admin",
                    PasswordHash = PasswordHasher.HashPassword("admin123"),
                    Role = "Admin",
                    FullName = "Admin User",
                    Email = "admin@t.com",
                    PhoneNumber = "1234567890",
                    WhatsApp = "1234567890",
                    Address = "123 Main St, Anytown, USA",
                    Description = "Admin User",
                    GUID = Guid.NewGuid(),
                    CreatedAt = DateTimeOffset.Now,
                    UpdatedAt = null,
                    DeletedAt = null
                },
                new User
                {
                    Username = "user",
                    PasswordHash = PasswordHasher.HashPassword("user123"),
                    Role = "User",
                    FullName = "Test User",
                    Email = "user@t.com",
                    PhoneNumber = "1234567891",
                    WhatsApp = "1234567891",
                    Address = "123 Main St, Anytown, ON",
                    Description = "Test User",
                    GUID = Guid.NewGuid(),
                    CreatedAt = DateTimeOffset.Now,
                    UpdatedAt = null,
                    DeletedAt = null
                }
            );
        }
    }
}
