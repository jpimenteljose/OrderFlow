using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OrderFlow.Domain.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task ModifyAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAsync
            (int page = 1, int pageSize = 10);
        Task<IEnumerable<TEntity>> GetAsync
            (Expression<Func<TEntity, bool>> where, 
             int page = 1, int pageSize = 10);
    }
}
