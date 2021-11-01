using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;
using Rent.Server.Repositories.Extensions;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace Rent.Server.Repositories
{
    public class AppRepository<T> : IAppRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public AppRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByTitle(string title)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(c => c.Title == title);
        }

        public virtual async Task<PagedList<T>> GetAll(PagingParameters pagedParameters)
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return PagedList<T>.ToPagedList(result, pagedParameters.PageNumber, pagedParameters.PageSize);
        }

        public virtual async Task<IEnumerable<T>> GetAllExpr(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                   .Where(predicate)
                   .ToListAsync();
        }

        public virtual async Task<T> Add(T entity)
        {
            var result = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<T> Edit(T entity)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Title == entity.Title);
            _dbContext.Entry(result).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public virtual async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
