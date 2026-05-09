using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RajMango.Application.Interfaces;
using RajMango.Domain.Common;

namespace RajMango.Infrastructure.Persistence
{
    public static class AuditingHelper
    {
        public static void ApplyAuditing(ChangeTracker changeTracker, ICurrentUserService userService)
        {
            //TODO: LATER
            var userId = userService.UserId;
            var now = Clock.Now();

            foreach (var entry in changeTracker.Entries<IFullAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;
                        //entry.Entity.CreatedBy = userId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = now;
                        //entry.Entity.UpdatedBy = userId;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = now;
                        //entry.Entity.DeletedBy = userId;
                        break;
                }
            }
        }
    }

}
