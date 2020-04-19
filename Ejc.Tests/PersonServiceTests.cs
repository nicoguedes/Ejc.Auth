using Ejc.Repository.Interfaces;
using Ejc.Services;
using Ejc.Services.Interfaces;
using Ejc.Tests.Mock;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ejc.Tests
{
    public class PersonServiceTests
    {
        private IPersonRepository _personRepository;
        private IPersonService _personService;

        public PersonServiceTests()
        {
            _personService = new PersonService();
            _personService.Initialize(new FakePersonRepository());
        }

        [Fact]
        public void Should_ReturnPerson_When_PersonExists()
        {
            string id = "abc123";
            var person = _personService.GetByIdAsync(id);
            Assert.NotNull(person);
        }

        [Fact]
        public void Should_FindPerson_When_NameExists()
        {
            string name = "Antonio Carlos";
            var person = _personService.GetByNameAsync(name);
            Assert.NotNull(person);
        }
    }
}
