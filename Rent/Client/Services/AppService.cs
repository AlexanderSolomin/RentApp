using System;
using System.Threading.Tasks;
using Rent.Shared.Request;

namespace Rent.Client.Services
{
    public class AppService<T> : IAppService<T> where T : class
    {
        public AppService() 
        {
        }

        public virtual Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<Features.PagedResponse<T>> GetAll(PagingParameters pagingParameters)
        {
            throw new NotImplementedException();
        }

        public virtual Task<System.Collections.Generic.IEnumerable<T>> GetAllExpr(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<Rent.Shared.Models.AppDataResult<T>> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
