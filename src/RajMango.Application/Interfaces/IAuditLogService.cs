namespace RajMango.Application.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(string tableName, int entityId, string actionType, string performedBy, object oldData, object newData);
    }
}
