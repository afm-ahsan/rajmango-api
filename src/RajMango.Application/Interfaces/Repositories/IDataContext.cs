using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RajMango.Application.Interfaces.Repositories
{
    public interface IDataContext : IDisposable
    {
        DatabaseFacade Database { get; }

        DbSet<TEntity> Get<TEntity>() where TEntity : class;

        int SaveChanges();

        //Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
