using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rent.Shared.Models;

namespace Rent.Client.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly HttpClient _httpClient;

        public Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppDataResult<T>> List(int skip = 0, int take = 5)
        {
            return await _httpClient.GetFromJsonAsync<AppDataResult<T>>($"");
        }   

        public Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<T> IService<T>.GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
