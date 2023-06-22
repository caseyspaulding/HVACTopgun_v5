using System.Linq.Expressions;

namespace HVACTopGun.UI
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                       string includeProperties = "");

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entityToUpdate);

        Task<bool> Delete(TEntity entityToDelete);
    }
}