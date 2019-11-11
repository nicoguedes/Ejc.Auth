using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejc.Auth.Repository.Interfaces;
using Ejc.Entities;

namespace Ejc.Services.Interfaces
{
    public interface IUserService
    {
        void Initialize(IUserRepository repository);
        User Authenticate(string email, string password);
    }
}
