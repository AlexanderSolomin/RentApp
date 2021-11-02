using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;

namespace Rent.Server.Repositories
{
    public interface IAppRepository<T>
    {
        Task<T> GetById(Guid id);
        // Task<T> GetByTitle(string title);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllExpr(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Delete(T entity);
        Task Edit(T entity);
    }
}
