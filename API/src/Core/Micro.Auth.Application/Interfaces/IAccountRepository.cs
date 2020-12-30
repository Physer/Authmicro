using Micro.Auth.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Micro.Auth.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
    }
}
