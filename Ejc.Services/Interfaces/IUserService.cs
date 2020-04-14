using Ejc.Entities;
using Ejc.Repository.Interfaces;
using System.Threading.Tasks;

namespace Ejc.Services.Interfaces
{
    public interface IUserService
    {
        void Initialize(IUserRepository repository);
        Task<User> AuthenticateAsync(string email, string password);
    }
}
