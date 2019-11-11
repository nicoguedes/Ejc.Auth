using System.Security.Authentication;
using Ejc.Entities;
using Ejc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ejc.Auth.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Ejc.Auth.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userService.Initialize(userRepository);
        }

        [HttpGet("test")]
        public IActionResult GetUsers()
        {
            return Ok(new { abc = "123" });
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            try
            {
                var user = _userService.Authenticate(userParam.Email, userParam.Password);
                return Ok(user);
            }
            catch (AuthenticationException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}