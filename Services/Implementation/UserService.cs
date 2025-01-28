using CharityManager.API.Model;
using CharityManager.API.Repositories.Interface;
using CharityManager.API.Services.Interface;

namespace CharityManager.API.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserModel>> GetUsersByRoleAsync(string role)
        {
            return await _userRepository.GetUsersByRoleAsync(role);
        }

        public UserCreateResponse CreateUser(UserCreateRequest userCreateRequest)
        {
            var result = _userRepository.CreateUser(userCreateRequest);
            _userRepository.SaveChanges();

            return result;
        }

        public void UpdateUser(int userId, UserUpdateRequest userUpdateRequest)
        {
            _userRepository.UpdateUser(userId, userUpdateRequest);
            _userRepository.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
            _userRepository.SaveChanges();
        }
    }
}
