using Micro.Auth.Application.Interfaces;
using Micro.Auth.Authentication.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace Micro.Auth.Authentication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public UsersController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticationRequest authenticationRequest)
        {
            try
            {
                _authenticationService.Authenticate(authenticationRequest.Username, authenticationRequest.Password);
                return Ok();
            }
            catch(SecurityException)
            {
                return Unauthorized();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
