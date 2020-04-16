using Microsoft.EntityFrameworkCore;
using Mnemosyne.Domain;
using Mnemosyne.Infrastructure.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mnemosyne.Infrastructure.EntityFramework.Context
{
    public partial class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected DbContext Context;
        protected DbSet<TEntity> DbSet {
            get { return Context.Set<TEntity>(); }
        }

        public RepositoryBase(IDataContext context)
        {
            Context = (DbContext)context;
        }

        #region CRUD Methods
        /// <summary>
        /// Adds a new aggregate root to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Adds a list of new aggregate root to the repository.
        /// </summary>
        /// <param name="list">The entity to add.</param>
        public virtual void Add(List<TEntity> list)
        {
            DbSet.AddRange(list);
        }

        /// <summary>
        /// Attaches a detached or proxied entity (same identity as an existing entity) and updates it.
        /// </summary>
        /// <param name="entity">The entity to attach and update.</param>
        public virtual void Update(TEntity entity)
        {
            // DbSet.Attach(entity).State = System.Data.Entity.EntityState.Modified;
            // DbSet.Attach(entity);
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        /// <summary>
        /// Deletes a batch of entities that match the criteria.
        /// </summary>
        /// <param name="criteria">The criteria to use to delete the entities.</param>
        public virtual void Delete(Expression<Func<TEntity, bool>> criteria)
        {
            var matches = Find(criteria);
            foreach (var obj in matches)
                DbSet.Remove(obj);
        }

        #endregion

        #region Query Methods
        public virtual IQueryable<TEntity> AsNoTracking()
        {
            return DbSet.AsNoTracking();
        }

        /// <summary>
        /// Returns all instances of this entity in the database.
        /// </summary>
        /// <returns>IQueryable of the entity.</returns>
        public virtual IQueryable<TEntity> All()
        {
            return DbSet.AsQueryable();
        }

        /// <summary>
        /// Returns true when this repository contains any entities both unsaved (local) or persisted.
        /// </summary>
        /// <returns>bool</returns>
        public virtual bool Any()
        {
            return DbSet.Local.Any() || DbSet.Any();
        }

        /// <summary>
        /// Returns true when this repository contains any entities both unsaved (local) or persisted that match the expression.
        /// </summary>
        /// <param name="criteria">The expression to test against the data store.</param>
        /// <returns>bool</returns>
        public virtual bool Any(Expression<Func<TEntity, bool>> criteria)
        {
            return DbSet.Local.Any(criteria.Compile()) || DbSet.Any(criteria);
        }

        /// <summary>
        /// Returns true when this repository contains any entities both unsaved (local) or persisted.
        /// </summary>
        /// <returns>bool</returns>
        public Task<bool> AnyAsync()
        {
            return DbSet.Local.Any() ? Task.FromResult(true) : DbSet.AnyAsync();
        }

        /// <summary>
        /// Returns true when this repository contains any entities both unsaved (local) or persisted that match the expression.
        /// </summary>
        /// <param name="criteria">The expression to test against the data store.</param>
        /// <returns>bool</returns>
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return DbSet.Local.Any(criteria.Compile()) ? Task.FromResult(true) : DbSet.AnyAsync(criteria);
        }

        /// <summary>
        /// Returns a IQueryable of this entity that matches the expression.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> criteria)
        {
            return DbSet.Where(criteria);
        }

        /// <summary>
        /// Returns an entity based on the ID value.
        /// </summary>
        /// <param name="id">The ID value to search for.</param>
        /// <returns>The entity if it was found.</returns>
        public virtual TEntity Get(TId id)
        {
            return DbSet.Local.FirstOrDefault(x => x.Id.Equals(id)) ?? DbSet.Find(id);
        }

        /// <summary>
        /// Gets an entity that matches the expression.
        /// </summary>
        /// <param name="criteria">The expression to match the entity against.</param>
        /// <returns>entity</returns>
        public virtual TEntity Get(Expression<Func<TEntity, bool>> criteria)
        {
            return DbSet.Local.FirstOrDefault(criteria.Compile()) ?? DbSet.FirstOrDefault(criteria);
        }

        /// <summary>
        /// Returns an entity based on the ID value.
        /// </summary>
        /// <param name="id">The ID value to search for.</param>
        /// <returns>The entity if it was found.</returns>
        public Task<TEntity> GetAsync(TId id)
        {
            var entity = DbSet.Local.FirstOrDefault(x => x.Id.Equals(id));
            return entity != null ? Task.FromResult(entity) : DbSet.FindAsync(id).AsTask();
        }

        /// <summary>
        /// Gets an entity that matches the expression.
        /// </summary>
        /// <param name="criteria">The expression to match the entity against.</param>
        /// <returns>entity</returns>
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> criteria)
        {
            var entity = DbSet.Local.FirstOrDefault(criteria.Compile());
            return entity != null ? Task.FromResult(entity) : DbSet.FirstOrDefaultAsync(criteria);
        }

        /// <summary>
        /// Returns true when any entity matches the critiera expression. Same as using Any().
        /// </summary>
        /// <param name="criteria">The criteria expression to look for.</param>
        /// <returns>bool</returns>
        public virtual bool Contains(Expression<Func<TEntity, bool>> criteria)
        {
            return Any(criteria);
        }

        /// <summary>
        /// Returns a count of all entities, both local (unsaved) and persisted.
        /// </summary>
        /// <returns>integer</returns>
        public virtual int Count()
        {
            return All().Count();
        }

        /// <summary>
        /// Returns a count of all entities that match the criteria expression.
        /// </summary>
        /// <param name="criteria">The criteria use to count the entities.</param>
        /// <returns>integer</returns>
        public virtual int Count(Expression<Func<TEntity, bool>> criteria)
        {
            return Find(criteria).Count();
        }

        /// <summary>
        /// Returns a count of all entities, both local (unsaved) and persisted.
        /// </summary>
        /// <returns>integer</returns>
        public Task<int> CountAsync()
        {
            return All().CountAsync();
        }

        /// <summary>
        /// Returns a count of all entities that match the criteria expression.
        /// </summary>
        /// <param name="criteria">The criteria use to count the entities.</param>
        /// <returns>integer</returns>
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return Find(criteria).CountAsync();

        }
        #endregion
    }
}