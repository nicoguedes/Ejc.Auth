using Ejc.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejc.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        protected readonly IMongoCollection<T> _collection;

        public GenericRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDatabase"));
            var database = client.GetDatabase("ejcdb");
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        private FilterDefinition<T> GetIdFilter(string id)
        {
            return Builders<T>.Filter.Eq("Id", id);
        }

        public async Task<T> CreateAsync(T obj)
        {
            await _collection.InsertOneAsync(obj);
            return obj;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            var result = await _collection.FindAsync(o => true);
            return result.ToList();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var result = await _collection.FindAsync<T>(GetIdFilter(id));

            return result.FirstOrDefault();
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(GetIdFilter(id));
        }

        public async Task<T> UpdateAsync(string id, T obj)
        {
            await _collection.ReplaceOneAsync(GetIdFilter(id), obj);
            return obj;
        }
    }
}
