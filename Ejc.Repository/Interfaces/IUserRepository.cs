using Ejc.Entities;
using Ejc.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejc.Auth.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Authenticate(string email, string password);
    }
}
