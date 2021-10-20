using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent.Shared.Models;
using System.Linq.Expressions;

namespace Rent.Server.Data
{
    public class AppRepository<T> : IAppRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public AppRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByName(string name)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(n => n.Name == name);
        }

        public virtual async Task<AppDataResult<T>> List(int skip = 0, int take = 5)
        {
            AppDataResult<T> result = new AppDataResult<T>()
            {
                Result = _dbContext.Set<T>().Skip(skip).Take(take),
                Count = await _dbContext.Set<T>().CountAsync()
            };
            return result;
        }

        public virtual async Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                   .Where(predicate)
                   .ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            var result = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<T> Edit(T entity)
        {
            var result = await _dbContext.Set<T>().FindAsync(entity);
            if (result != null)
            {
                result = entity;
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
