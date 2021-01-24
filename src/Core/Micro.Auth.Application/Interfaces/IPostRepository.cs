using Micro.Auth.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Micro.Auth.Application.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}
