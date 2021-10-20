using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rent.Shared.Models;

namespace Rent.Client.Services
{
    public class CitiesService : IService<City>
    {
        private readonly HttpClient _httpClient;

        public CitiesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

        public async Task<AppDataResult<City>> List(int skip = 0, int take = 5)
        {
            return await _httpClient.GetFromJsonAsync<AppDataResult<City>>($"api/cities?skip={skip}&take={take}");
        }

        public Task<IEnumerable<City>> List(Expression<Func<City, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<City> IService<City>.GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
