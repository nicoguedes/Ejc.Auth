using Ejc.Entities;
using Ejc.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Ejc.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config) { }
        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var result = await _collection.FindAsync<User>(o => o.Email == email && o.Password == password);
            return result.FirstOrDefault();
        }
    }
}
