using Ejc.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejc.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        public T Create(T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public T Update(string id, T obj)
        {
            throw new NotImplementedException();
        }
    }
}
