using Ejc.Entities;
using Ejc.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejc.Repository.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<IList<Person>> GetByNameAsync(string name);

        Task<IList<string>> GetTagsAsync(string fieldName);
    }
}
