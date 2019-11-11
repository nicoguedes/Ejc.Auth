using Ejc.Auth.Repository.Interfaces;
using Ejc.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejc.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public User Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
