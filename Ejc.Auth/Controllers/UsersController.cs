using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Ejc.Entities;
using Ejc.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ejc.Auth.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

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