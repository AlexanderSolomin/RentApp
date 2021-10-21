using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rent.Shared.Models;

namespace Rent.Client.Services
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<T> GetByName(string name);
        Task<AppDataResult<T>> List(int skip, int take, string orderBy);
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<T> Edit(T entity);
    }
}
