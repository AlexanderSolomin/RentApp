using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Client.Features;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Linq;  
using System.Web;  

namespace Rent.Client.Services
{
    public class CitiesService : AppService<City>, ICitiesService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public CitiesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<PagedResponse<City>> GetCitiesPaged(PagingParameters pagingParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["searchTerm"] = pagingParameters.SearchTerm == null ? "" : pagingParameters.SearchTerm,
                ["orderBy"] = pagingParameters.OrderBy
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("api/cities", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagedResponse = new PagedResponse<City>
            {
                Items = JsonSerializer.Deserialize<List<City>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            foreach (var city in pagedResponse.Items)
            {
                Console.WriteLine(city.Title);
            }
            return pagedResponse;
        }

        public async Task AddCity(City city)
        {
            await _httpClient.PostAsJsonAsync("api/cities", city);
        }
    }
}
