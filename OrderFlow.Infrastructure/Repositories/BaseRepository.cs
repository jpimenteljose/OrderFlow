using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OrderFlow.Domain.Interfaces;
using OrderFlow.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OrderFlow.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> (DataContext _dataContext) 
        : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        public async Task AddAsync(TEntity entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public async Task ModifyAsync(TEntity entity)
        {
            _dataContext.Update(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dataContext.Remove(entity);
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(int page = 1, int pageSize = 10)
        {
            return await _dataContext.Set<TEntity>()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, int page = 1, int pageSize = 10)
        {
            return await _dataContext.Set<TEntity>()
                .Where(where)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
