using Ejc.Auth.Repository.Interfaces;
using Ejc.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;


namespace Ejc.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config) { }
        public User Authenticate(string email, string password)
        {
            // TODO: Password MD5 hash
            return _collection.Find<User>(o => o.Email == email && o.Password == password).FirstOrDefault();
        }
    }
}
