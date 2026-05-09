using Newtonsoft.Json;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using RajMango.Domain.Entities;

namespace RajMango.Infrastructure.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IDataContext _dataContext;
        private readonly IErrorHandler _errorHandler;

        public AuditLogService(IDataContext dataContext, IErrorHandler errorHandler)
        {
            _dataContext = dataContext;
            _errorHandler = errorHandler;
        }

        public async Task LogAsync(string tableName, int entityId, string actionType, string performedBy, object oldData, object newData)
        {
            var audit = new AuditLog
            {
                TableName = tableName,
                EntityId = entityId,
                ActionType = actionType,
                PerformedBy = performedBy,
                PerformedAt = DateTime.UtcNow,
                PreviousData = oldData != null ? JsonConvert.SerializeObject(oldData) : null,
                NewData = newData != null ? JsonConvert.SerializeObject(newData) : null
            };

            try
            {
                _dataContext.Get<AuditLog>().Add(audit);
                await _dataContext.SaveChangesAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex);
            }
        }
    }
}
