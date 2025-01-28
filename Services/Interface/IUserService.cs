using CharityManager.API.Model;

namespace CharityManager.API.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsersByRoleAsync(string role);
        UserCreateResponse CreateUser(UserCreateRequest userCreateRequest);
        void UpdateUser(int userId, UserUpdateRequest userUpdateRequest);
        void DeleteUser(int userId);
    }
}
