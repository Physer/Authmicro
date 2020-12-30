using Micro.Auth.Application.Interfaces;
using Micro.Auth.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Micro.Auth.Administration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = AuthenticationConstants.AdministratorPolicyName)]
    public class AdministrationController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AdministrationController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Entry() => Ok("Please call a secured endpoint!");

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers() => Ok(await _accountRepository.GetAccounts());
    }
}
