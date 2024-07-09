
using EventCase.Common.Entities;
using System.Linq.Expressions;

namespace EventCase.Common.Repositories
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : struct
    {
        Task<TEntity> GetAsync(TKey id);
        Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> AddAsync(TEntity entity, bool autoSave = true);
        Task AddManyAsync(IEnumerable<TEntity> entities, bool autoSave = true);
        Task RemoveAsync(TEntity entity, bool autoSave = true);
        Task RemoveManyAsync(IEnumerable<TEntity> entities, bool autoSave = true);
        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = true);
        Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = true);
        Task SaveChanges();
    }
}
