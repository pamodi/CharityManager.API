using CharityManager.API.Model;

namespace CharityManager.API.Repositories.Interface
{
    public interface IUserRepository : IRepo
    {
        Task<IEnumerable<UserModel>> GetUsersByRoleAsync(string role);
        UserCreateResponse CreateUser(UserCreateRequest userCreateRequest);
        void UpdateUser(int userId, UserUpdateRequest userUpdateRequest);
        void DeleteUser(int userId);
    }
}
