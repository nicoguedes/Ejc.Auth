using Ejc.Entities;
using Ejc.Auth.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejc.Auth.Repository.Interfaces;

namespace Ejc.Auth.Services
{
    public class UserService : IUserService
    {
        IUserRepository _repository;
        public void Initialize(IUserRepository repository)
        {
            _repository = repository;
        }
        public User Authenticate(string email, string password)
        {
            User user = _repository.Authenticate(email, password);

            return user;
        }

    }
}
