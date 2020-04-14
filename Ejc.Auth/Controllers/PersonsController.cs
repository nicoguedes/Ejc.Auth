using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejc.Repository.Interfaces;
using Ejc.Entities;
using Ejc.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService, IPersonRepository personRepository)
        {
            _personService = personService;
            _personService.Initialize(personRepository);
        }

        // GET: api/Person?name=abc
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var result = string.IsNullOrEmpty(name) ? await _personService.GetAllAsync() : await _personService.GetByNameAsync(name);
            return Ok(result);
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _personService.GetByIdAsync(id);
            return Ok(result);
        }

        // POST: api/Person
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Person person)
        {
            Person p = await _personService.CreateAsync(person);
            return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Person person)
        {
            Person p = await _personService.UpdateAsync(person);
            return Ok(p);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            await _personService.DeleteAsync(id);
            return Ok();
        }
    }
}
