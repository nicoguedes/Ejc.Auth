using Ejc.Entities;
using Ejc.Repository.Interfaces;
using Ejc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejc.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _repository;
        public void Initialize(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> CreateAsync(Person p)
        {
            var result = await _repository.CreateAsync(p);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IList<Person>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result;
        }

        public async Task<Person> GetByIdAsync(string id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result;
        }

        public async Task<Person> UpdateAsync(string id, Person p)
        {
            p.Id = id;
            p.DateOfBirth = p.DateOfBirth.Date;
            var result = await _repository.UpdateAsync(id, p);
            return result;
        }

        public async Task<IList<Person>> GetByNameAsync(string name)
        {
            var result = await _repository.GetByNameAsync(name);
            return result;
        }

        public Task<IList<string>> GetTagsAsync(string fieldName)
        {
            return _repository.GetTagsAsync(fieldName);
        }
    }
}
