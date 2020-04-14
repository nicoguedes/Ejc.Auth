using Ejc.Entities;
using System.Threading.Tasks;

namespace Ejc.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AuthenticateAsync(string email, string password);
    }
}
