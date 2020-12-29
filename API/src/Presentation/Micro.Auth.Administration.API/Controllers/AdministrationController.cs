using Micro.Auth.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Auth.Administration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = AuthenticationConstants.AdministratorPolicyName)]
    public class AdministrationController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Entry() => Ok("Please call a secured endpoint!");

        [HttpGet("users")]
        public IActionResult GetUsers() => Ok("Congratulations! You've got all the rights to retrieve user information!");
    }
}
