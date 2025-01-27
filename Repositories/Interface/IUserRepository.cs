using CharityManager.API.Model;
using CharityManager.API.Model.Common;

namespace CharityManager.API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsersByRoleAsync(string role);
    }
}
