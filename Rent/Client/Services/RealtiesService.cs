using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Client.Features;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Rent.Client.Services
{
    public class RealtiesService : AppService<Realty>, IRealtiesService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly ILogger<RealtiesService> _logger;

        public RealtiesService(HttpClient httpClient, ILogger<RealtiesService> logger) : base(httpClient)
        {
            _httpClient = httpClient;
            _logger = logger;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<PagedResponse<Realty>> GetRealtiesPaged(PagingParameters pagingParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["searchTerm"] = pagingParameters.SearchTerm == null ? "" : pagingParameters.SearchTerm,
                ["orderBy"] = pagingParameters.OrderBy
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("api/realties", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagedResponse = new PagedResponse<Realty>
            {
                Items = JsonSerializer.Deserialize<List<Realty>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            foreach (var city in pagedResponse.Items)
            {
                Console.WriteLine(city.Title);
            }
            return pagedResponse;
        }

        public async Task<string> UploadImage(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync($"{_httpClient.BaseAddress.AbsoluteUri}api/upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine(_httpClient.BaseAddress.AbsoluteUri, postContent);
                return imgUrl;
            }
        }

        public async Task<Realty> GetRealtyById(string id)
        {
            return await _httpClient.GetFromJsonAsync<Realty>($"api/realties/{id}");
        }

        public async Task EditRealty(Realty realty)
        {
            await _httpClient.PutAsJsonAsync($"api/realties/{realty.Id}", realty);
        }

        public async Task AddRealty(Realty realty)
        {
            _logger.LogInformation($"{DateTime.Now}: Added realty with id {realty.Id}, owner: {realty.OwnerId}");
            await _httpClient.PostAsJsonAsync("api/realties/", realty);
        }

        public async Task DeleteRealty(Guid id)
        {
			await _httpClient.DeleteAsync($"api/realties/{id}");
        }
    }
}