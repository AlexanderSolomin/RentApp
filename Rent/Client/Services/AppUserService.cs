using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rent.Shared.Models;

namespace Rent.Client.Services
{
    public class AppUserService : AppService<AppUser>, IAppUserService
    {
        private readonly HttpClient _httpClient;

        public AppUserService(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<AppUser> GetUserById(string id)
        {
            return await _httpClient.GetFromJsonAsync<AppUser>($"api/appuser/{id}");
        }

    }
}
