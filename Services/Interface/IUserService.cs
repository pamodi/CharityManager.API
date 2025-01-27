using CharityManager.API.Model;

namespace CharityManager.API.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsersByRoleAsync(string role);
    }
}
