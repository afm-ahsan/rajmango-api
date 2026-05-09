using Microsoft.EntityFrameworkCore;

namespace RajMango.Application.Interfaces.Repositories
{
    public interface IDataContext : IDisposable
    {
        DbSet<TEntity> Get<TEntity>() where TEntity : class;
        
        int SaveChanges();
        
        //Task<int> SaveChangesAsync();
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
