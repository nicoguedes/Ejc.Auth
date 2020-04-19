using Ejc.Repository.Interfaces;
using Ejc.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejc.Services.Interfaces
{
    public interface IPersonService
    {
        void Initialize(IPersonRepository repository);
        Task<IList<Person>> GetAllAsync();
        Task<IList<Person>> GetByNameAsync(string name);
        Task<Person> GetByIdAsync(string id);
        Task<Person> CreateAsync(Person p);
        Task<Person> UpdateAsync(string id, Person p);
        Task DeleteAsync(string id);
        Task<IList<string>> GetTagsAsync(string fieldName);
    }
}
