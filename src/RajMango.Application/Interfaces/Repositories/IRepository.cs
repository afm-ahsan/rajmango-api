using System.Linq.Expressions;

namespace RajMango.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TKey id);
        Task<int> SaveChangesAsync();
        Task<int> CountAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            int skipCount = 0,
                                            int maxResultCount = 0,
                                            string includeProperties = "");
    }
}
