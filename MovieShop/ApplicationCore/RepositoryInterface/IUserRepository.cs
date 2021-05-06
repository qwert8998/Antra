using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string Email);
    }
}
