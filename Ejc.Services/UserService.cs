using Ejc.Entities;
using Ejc.Jwt;
using Ejc.Repository.Interfaces;
using Ejc.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Ejc.Services
{
    public class UserService : IUserService
    {
        IUserRepository _repository;
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void Initialize(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> AuthenticateAsync(string email, string password)
        {
            User user = await _repository.AuthenticateAsync(email, password);

            if (user == null)
                throw new AuthenticationException("Invalid username or password.");

            TokenGenerator tokenGenerator = new TokenGenerator(_appSettings.Secret);
            user.Token = tokenGenerator.GenerateToken(user);

            user.Password = null;

            return user;
        }

    }
}
