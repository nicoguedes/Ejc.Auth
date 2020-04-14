using Ejc.Entities;
using Ejc.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Ejc.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(IConfiguration config) : base(config) { }

        public async Task<IList<Person>> GetByNameAsync(string name)
        {
            var result = await _collection.FindAsync<Person>(p => p.Name.Contains(name));
            return result.ToList();
        }

        public async Task<IList<string>> GetTagsAsync(string fieldName)
        {
            var result = await _collection.Distinct<string>(fieldName, FilterDefinition<Person>.Empty).ToListAsync();

            return result.Where(s => !string.IsNullOrEmpty(s)).ToList();
        }
    }
}
