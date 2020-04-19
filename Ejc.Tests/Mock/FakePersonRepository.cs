using Ejc.Entities;
using Ejc.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejc.Tests.Mock
{
    public class FakePersonRepository : IPersonRepository
    {
        private List<Person> personsMockData;

        public FakePersonRepository()
        {
            personsMockData = new List<Person>()
            {
                new Person("Antonio Carlos da Silva Costa", "33335555", new DateTime(1980, 1, 1), "abc@abc.com") { Id = Guid.NewGuid().ToString() },
                new Person("Jose Carlos Oliveira", "33335555", new DateTime(1980, 1, 1), "abc@abc.com") { Id = "abc123" },

            };
        }

        public async Task<Person> CreateAsync(Person obj)
        {
            personsMockData.Add(obj);
            return obj;
        }

        public async Task DeleteAsync(string id)
        {
            personsMockData.Remove(personsMockData.Where(p => p.Id == id).FirstOrDefault());
        }

        public async Task<IList<Person>> GetAllAsync()
        {
            return personsMockData;
        }

        public async Task<Person> GetByIdAsync(string id)
        {
            return personsMockData.Find(p => p.Id == id);
        }

        public async Task<IList<Person>> GetByNameAsync(string name)
        {

        }

        public Task<IList<string>> GetTagsAsync(string fieldName)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateAsync(string id, Person obj)
        {
            throw new NotImplementedException();
        }
    }
}
