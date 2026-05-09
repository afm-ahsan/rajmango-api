using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using RajMango.Domain.Entities;

namespace RajMango.Infrastructure.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        //                                                                            InterceptionResult<int> result,
        //                                                                            CancellationToken cancellationToken = default)
        //{
        //    var context = eventData.Context;
        //    if (context == null) return result;

        //    var user = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System";

        //    var entries = context.ChangeTracker.Entries()
        //        .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted);

        //    foreach (var entry in entries)
        //    {
        //        var tableName = entry.Metadata.GetTableName();
        //        var id = (int)entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue;

        //        var audit = new AuditLog
        //        {
        //            TableName = tableName,
        //            EntityId = id,
        //            ActionType = entry.State.ToString(),
        //            PerformedBy = user,
        //            PerformedAt = DateTime.UtcNow,
        //            PreviousData = entry.State == EntityState.Modified || entry.State == EntityState.Deleted
        //                ? JsonConvert.SerializeObject(entry.OriginalValues.ToObject())
        //                : null,
        //            NewData = entry.State == EntityState.Modified || entry.State == EntityState.Added
        //                ? JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
        //                : null
        //        };

        //        context.Set<AuditLog>().Add(audit);
        //    }

        //    return await base.SavingChangesAsync(eventData, result, cancellationToken);
        //}
    }

}
