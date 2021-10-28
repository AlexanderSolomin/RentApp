using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Client.Features;

namespace Rent.Client.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<AppDataResult<T>> GetByTitle(string title, int skip = 0, int take = 5, string orderBy = "Title");
        Task<PagedResponse<T>> List(PagingParameters pagingParameters);
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<T> Edit(T entity);
    }
}
