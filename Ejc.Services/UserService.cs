using Ejc.Entities;
using Ejc.Services.Interfaces;
using Ejc.Auth.Repository.Interfaces;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;
using Ejc.Jwt;
using Microsoft.Extensions.Options;

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
        public User Authenticate(string email, string password)
        {
            User user = _repository.Authenticate(email, password);

            if (user == null)
                throw new AuthenticationException("Invalid username or password.");

            TokenGenerator tokenGenerator = new TokenGenerator(_appSettings.Secret);
            user.Token = tokenGenerator.GenerateToken(user);

            user.Password = null;

            return user;
        }

    }
}
