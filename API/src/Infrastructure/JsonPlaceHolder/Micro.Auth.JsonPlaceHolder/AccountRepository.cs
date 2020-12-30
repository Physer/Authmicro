using Micro.Auth.Application.Interfaces;
using Micro.Auth.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Micro.Auth.JsonPlaceHolder
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = await client.GetStringAsync("/users");
            if (string.IsNullOrWhiteSpace(request))
                throw new Exception("No users found");

            var accounts = JsonConvert.DeserializeObject<IEnumerable<Account>>(request);
            return accounts;
        }
    }
}
