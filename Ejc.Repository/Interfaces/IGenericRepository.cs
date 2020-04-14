using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejc.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(string id, T obj);
        Task<T> GetByIdAsync(string id);
        Task<IList<T>> GetAllAsync();
        Task DeleteAsync(string id);
    }
}
