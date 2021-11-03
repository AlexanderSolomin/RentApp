using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rent.Client.Features;
using Rent.Shared.Request;

namespace Rent.Client.Services
{
	public class AppService<T> : IAppService<T> where T : class
	{
		private readonly HttpClient _httpClient;
		public AppService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public virtual Task Add(T entity)
		{
			throw new NotImplementedException();
		}

		public virtual Task Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public virtual Task Edit(T entity)
		{
			throw new NotImplementedException();
		}

		public virtual Task<PagedResponse<T>> GetAll(PagingParameters pagingParameters)
		{
			throw new NotImplementedException();
		}

		public virtual Task<System.Collections.Generic.IEnumerable<T>> GetAllExpr(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public virtual Task<T> GetById(string id)
		{
			throw new NotImplementedException();
		}

		public virtual Task<T> GetByTitle(string title)
		{
			throw new NotImplementedException();
		}
	}
}
