using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;

namespace Rent.Server.Data
{
    public interface IAppRepository<T>
    {
        Task<T> GetById(Guid id);
        Task<AppDataResult<T>> GetByTitle(string title, int skip = 0, int take = 5, string orderBy = "Title");
        Task<PagedList<T>> List(PagingParameters realtyParameters);
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<T> Edit(T entity);
    }
}
