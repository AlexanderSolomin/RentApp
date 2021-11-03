using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Client.Features;

namespace Rent.Client.Services
{
    public interface IAppService<T> where T : class
    {
        Task<T> GetById(string id);
        Task<T> GetByTitle(string title);
        Task<PagedResponse<T>> GetAll(PagingParameters pagingParameters);
        Task<IEnumerable<T>> GetAllExpr(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Delete(T entity);
        Task Edit(T entity);
    }
}
