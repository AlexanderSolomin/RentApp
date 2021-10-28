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
    public class CitiesService : IService<City>
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public CitiesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<City> Add(City entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(City entity)
        {
            throw new NotImplementedException();
        }

        public Task<City> Edit(City entity)
        {
            throw new NotImplementedException();
        }

        public Task<City> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResponse<City>> List(PagingParameters pagingParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString()
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("cities", queryStringParam));
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
            return pagedResponse;

            // return await _httpClient
            // .GetFromJsonAsync<AppDataResult<City>>($"api/cities?skip={skip}&take={take}&orderby={orderBy}");
        }

        public Task<IEnumerable<City>> List(Expression<Func<City, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<AppDataResult<City>> GetByTitle(string title, int skip = 0, int take = 5, string orderBy = "Title")
        {
            return await _httpClient
            .GetFromJsonAsync<AppDataResult<City>>($"api/cities?title={title}?skip={skip}&take={take}&orderby={orderBy}");
        }
    }
}
