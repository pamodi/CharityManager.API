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
    }
}
