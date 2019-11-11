using Ejc.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Ejc.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        protected readonly IMongoCollection<T> _collection;

        public GenericRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDatabase"));
            var database = client.GetDatabase("UsersDb");
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public T Create(T obj)
        {
            _collection.InsertOne(obj);
            return obj;
        }

        public IList<T> GetAll()
        {
            return _collection.Find(o => true).ToList();
        }

        public T GetById(string id)
        {
            return _collection.Find<T>(o => Convert.ToString(o.GetType().GetProperty("Id").GetValue(o, null)) == id).FirstOrDefault();
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(o => Convert.ToString(o.GetType().GetProperty("Id").GetValue(o, null)) == id);
        }

        public T Update(string id, T obj)
        {
            _collection.ReplaceOne(o => Convert.ToString(o.GetType().GetProperty("Id").GetValue(o, null)) == id, obj);
            return obj;
        }
    }
}
