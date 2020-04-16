using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mnemosyne.Infrastructure.Interfaces.Context
{
    public interface IRepositoryBase<TEntity, in TId>
    {
        IQueryable<TEntity> AsNoTracking();
        IQueryable<TEntity> All();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> criteria);

        bool Any();
        bool Any(Expression<Func<TEntity, bool>> criteria);

        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> criteria);

        TEntity Get(TId id);
        TEntity Get(Expression<Func<TEntity, bool>> criteria);

        Task<TEntity> GetAsync(TId id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> criteria);

        int Count();
        int Count(Expression<Func<TEntity, bool>> criteria);

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);

        void Add(TEntity entity);
        void Add(List<TEntity> entity);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> criteria);
        void Update(TEntity entity);
    }
}