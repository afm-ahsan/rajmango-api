using Microsoft.EntityFrameworkCore;
using RajMango.Application.Interfaces.Repositories;
using RajMango.DataAccess.Contexts;
using System.Linq.Expressions;

namespace RajMango.DataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly AppDbContext _dbContext;
        private bool _disposed = false;

        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<int> DeleteAsync(TKey id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity == null) { return 0; }

            _dbContext.Set<TEntity>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public virtual async Task<int> CountAsync() => await _dbContext.Set<TEntity>().CountAsync();

        public virtual async Task<TEntity> GetByIdAsync(TKey id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
                                                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                 int skipCount = 0,
                                                                 int maxResultCount = 0,
                                                                 string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (skipCount > 0)
            {
                query = query.Skip(skipCount);
            }

            if (maxResultCount > 0)
            {
                query = query.Take(maxResultCount);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            //RajMango.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
