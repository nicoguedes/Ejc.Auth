using System;
using System.Collections.Generic;
using System.Text;

namespace Ejc.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        T Create(T obj);
        T Update(string id, T obj);
        T GetById(string id);
        IList<T> GetAll();
        void Delete(string id);
    }
}
