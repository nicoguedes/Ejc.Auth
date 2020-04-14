using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejc.Repository.Interfaces;
using Ejc.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private IPersonService _personService;

        public TagsController(IPersonService personService, IPersonRepository personRepository)
        {
            _personService = personService;
            _personService.Initialize(personRepository);
        }

        [HttpGet]
        public async Task<IActionResult> GetTags(string fieldName)
        {
            var tags = await _personService.GetTagsAsync(fieldName);
            return Ok(tags);
        }
    }
}