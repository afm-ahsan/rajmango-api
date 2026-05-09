using RajMango.Application.Interfaces.Repositories;
using RajMango.DataAccess.Contexts;
using RajMango.Domain.Entities;
using RajMango.Infrastructure;

namespace RajMango.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<AppUser, int>
    {
    }

    [TransientRegistration]
    public class UserRepository : RepositoryBase<AppUser, int>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
