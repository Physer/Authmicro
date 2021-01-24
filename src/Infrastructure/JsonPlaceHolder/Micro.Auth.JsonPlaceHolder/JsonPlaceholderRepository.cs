using Micro.Auth.Application.Interfaces;
using Micro.Auth.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Micro.Auth.JsonPlaceHolder
{
    public class JsonPlaceholderRepository : IAccountRepository, IPostRepository
    {
        private readonly HttpClient _httpClient;

        public JsonPlaceholderRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "/users");
            return await GetMany<Account>(httpRequest);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "/posts");
            return await GetMany<Post>(httpRequest);
        }

        private async Task<IEnumerable<T>> GetMany<T>(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("Unable to complete the HTTP request");

            return JsonConvert.DeserializeObject<IEnumerable<T>>(await response.Content.ReadAsStringAsync());
        }
    }
}
