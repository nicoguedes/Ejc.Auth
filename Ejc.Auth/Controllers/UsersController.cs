using System.Security.Authentication;
using Ejc.Entities;
using Ejc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ejc.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Ejc.Api.Controllers
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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userParam)
        {
            try
            {
                var user = await _userService.AuthenticateAsync(userParam.Email, userParam.Password);
                return Ok(user);
            }
            catch (AuthenticationException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}