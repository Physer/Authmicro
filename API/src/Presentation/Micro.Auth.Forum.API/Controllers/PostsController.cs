using Micro.Auth.Application.Interfaces;
using Micro.Auth.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Micro.Auth.Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = AuthenticationConstants.ReaderPolicyName)]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts() => Ok(await _postRepository.GetPosts());
    }
}
