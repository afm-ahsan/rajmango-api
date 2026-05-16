using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RajMango.Application.Interfaces;
using RajMango.Domain.Common;

namespace RajMango.Infrastructure.Persistence
{
    public static class AuditingHelper
    {
        // Seed data creates System Admin with Id = 1.
        // Used as the fallback CreatedBy/UpdatedBy for unauthenticated operations
        // (self-registration, background jobs, seeding).
        private const int SystemUserId = 1;

        public static void ApplyAuditing(ChangeTracker changeTracker, ICurrentUserService userService)
        {
            var userId = userService.UserId != 0 ? userService.UserId : SystemUserId;
            var now = Clock.Now();

            foreach (var entry in changeTracker.Entries<IFullAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;
                        // Preserve explicit CreatedBy set by system-level handlers (e.g. registration
                        // sets CreatedBy = newUser.Id so the new user is their own creator).
                        if (entry.Entity.CreatedBy == 0)
                            entry.Entity.CreatedBy = userId;
                        break;

                    case EntityState.Modified:
                        entry.Property("CreatedAt").IsModified = false;
                        entry.Property("CreatedBy").IsModified = false;
                        entry.Entity.UpdatedAt = now;
                        entry.Entity.UpdatedBy = userId;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Property("CreatedAt").IsModified = false;
                        entry.Property("CreatedBy").IsModified = false;
                        entry.Entity.IsDeleted  = true;
                        entry.Entity.DeletedAt  = now;
                        entry.Entity.DeletedBy  = userId;
                        entry.Entity.UpdatedAt  = now;
                        entry.Entity.UpdatedBy  = userId;
                        break;
                }
            }
        }
    }

}
