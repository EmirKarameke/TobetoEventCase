using EventCase.Common.Entities;
using EventCase.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace EventCase.EntityFrameworkCore
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        EventCaseContext context;

        protected RepositoryBase(EventCaseContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity, bool autoSave = true)
        {
            context.Add(entity);

            if (autoSave) { context.SaveChanges(); }

            return entity;
        }

        public async Task AddManyAsync(IEnumerable<TEntity> entities, bool autoSave = true)
        {
            //context.Set<TEntity>().AddRange(entities);
            if (autoSave) { context.SaveChanges(); };
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = context.Set<TEntity>().Where(predicate);

            if (!includeProperties.IsNullOrEmpty())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (!includeProperties.IsNullOrEmpty())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return query;
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return context.Set<TEntity>().FirstOrDefault(i => i.Id.Equals(id));
        }

        public async Task RemoveAsync(TEntity entity, bool autoSave = true)
        {
            context.Set<TEntity>().Remove(entity);
            if (autoSave) { context.SaveChanges(); }
        }

        public async Task RemoveManyAsync(IEnumerable<TEntity> entities, bool autoSave = true)
        {
            foreach (var item in entities)
            {
                context.Set<TEntity>().Remove(item);
            }
            if (autoSave) { context.SaveChanges(); };

        }

        public async Task SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {

            var query = context.Set<TEntity>().Where(predicate).AsQueryable();
            if (includeProperties != null)
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = true)
        {
            context.Set<TEntity>().Update(entity);

            if (autoSave) { context.SaveChanges(); }

            return entity;
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = true)
        {
            foreach (var item in entities)
            {

                context.Set<TEntity>().Update(item);
            }

            if (autoSave) { context.SaveChanges(); }
        }
    }
}
