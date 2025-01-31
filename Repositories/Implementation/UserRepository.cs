using CharityManager.API.Data;
using CharityManager.API.Entity;
using CharityManager.API.Model;
using CharityManager.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CharityManager.API.Repositories.Implementation
{
    public class UserRepository : BaseRepo, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<UserModel>> GetUsersByRoleAsync(string role)
        {
            return await _context.Users
                                 .Where(u => u.Role == role && u.DeletedAt == null)
                                 .Select(q => new UserModel()
                                 {
                                     Id = q.Id,
                                     Email = q.Email,
                                     DisplayName = q.FirstName + " " + q.LastName,
                                     FirstName = q.FirstName,
                                     LastName = q.LastName,
                                     PhoneNumber = q.PhoneNumber,
                                     Role = q.Role,
                                     WhatsApp = q.WhatsApp,
                                     Guid = q.Guid,
                                     Description = q.Description,
                                     CreatedAt = q.CreatedAt,
                                     UpdatedAt = q.UpdatedAt
                                 }).ToListAsync();
        }

        public UserModel GetUserDetails(int userId)
        {
            var user = _context.Users.FirstOrDefault(q => q.Id == userId && q.DeletedAt == null) ?? throw new InvalidOperationException("User not found.");

            var address = new AddressModel();
            if (user.Address != null)
                address = JsonSerializer.Deserialize<AddressModel>(user.Address);

            return new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.FirstName + " " + user.LastName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                WhatsApp = user.WhatsApp,
                Street = address.Street,
                City = address.City,
                Province = address.Province,
                Country = address.Country,
                PostalCode = address.PostalCode,
                Guid = user.Guid,
                Description = user.Description,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public UserCreateResponse CreateUser(UserCreateRequest userCreateRequest)
        {
            if (_context.Users.Any(u => ((u.FirstName == userCreateRequest.FirstName || u.Email == userCreateRequest.Email) && u.DeletedAt == null)))
                throw new InvalidOperationException("User already exists.");

            var address = new
            {
                userCreateRequest.Street,
                userCreateRequest.City,
                userCreateRequest.Province,
                userCreateRequest.Country,
                userCreateRequest.PostalCode
            };

            var user = new User
            {
                Role = "USER",
                FirstName = userCreateRequest.FirstName,
                LastName = userCreateRequest.LastName,
                Email = userCreateRequest.Email,
                PhoneNumber = userCreateRequest.PhoneNumber,
                WhatsApp = userCreateRequest.WhatsApp,
                Address = JsonSerializer.Serialize(address),
                Guid = Guid.NewGuid(),
                Description = userCreateRequest.Description
            };

            _context.Users.Add(user);

            return new UserCreateResponse { Id = user.Id };
        }

        public void UpdateUser(int userId, UserUpdateRequest userUpdateRequest)
        {
            var user = _context.Users.FirstOrDefault(q => q.Id == userId && q.DeletedAt == null) ?? throw new InvalidOperationException("User not found.");

            var address = new
            {
                userUpdateRequest.Street,
                userUpdateRequest.City,
                userUpdateRequest.Province,
                userUpdateRequest.Country,
                userUpdateRequest.PostalCode
            };

            user.FirstName = userUpdateRequest.FirstName;
            user.LastName = userUpdateRequest.LastName;
            user.Email = userUpdateRequest.Email;
            user.PhoneNumber = userUpdateRequest.PhoneNumber;
            user.WhatsApp = userUpdateRequest.WhatsApp;
            user.Address = JsonSerializer.Serialize(address);
            user.Description = userUpdateRequest.Description;
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(q => q.Id == userId && q.DeletedAt == null) ?? throw new InvalidOperationException("User not found.");

            user.MarkAsDelete<User>();
        }
    }
}
