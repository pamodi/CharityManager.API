using CharityManager.API.Model;

namespace CharityManager.API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsersByRoleAsync(string role);
    }
}
