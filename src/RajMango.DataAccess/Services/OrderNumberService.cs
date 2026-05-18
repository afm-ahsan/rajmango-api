using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RajMango.Application.Interfaces;
using RajMango.Application.Interfaces.Repositories;
using System.Data;
using System.Globalization;

namespace RajMango.DataAccess.Services
{
    public class OrderNumberService : IOrderNumberService
    {
        private readonly IDataContext _dataContext;
        private readonly ILogger<OrderNumberService> _logger;

        private const string MergeSql = @"
            MERGE INTO OrderNumberCounters WITH (HOLDLOCK) AS target
            USING (VALUES (@today)) AS source (Date) ON target.Date = source.Date
            WHEN MATCHED THEN
                UPDATE SET Counter = target.Counter + 1
            WHEN NOT MATCHED THEN
                INSERT (Date, Counter) VALUES (@today, 1)
            OUTPUT inserted.Counter;";

        public OrderNumberService(IDataContext dataContext, ILogger<OrderNumberService> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<string> GenerateAsync(CancellationToken cancellationToken = default)
        {
            var today = DateTime.Now.Date;
            var conn = _dataContext.Database.GetDbConnection();

            var mustOpen = conn.State != ConnectionState.Open;
            if (mustOpen)
                await _dataContext.Database.OpenConnectionAsync(cancellationToken);

            try
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = MergeSql;

                var p = cmd.CreateParameter();
                p.ParameterName = "@today";
                p.Value = today;
                p.DbType = DbType.Date;
                cmd.Parameters.Add(p);

                var scalar = await cmd.ExecuteScalarAsync(cancellationToken);
                var counter = Convert.ToInt32(scalar);

                var formattedDate = today.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
                var orderNumber = $"{formattedDate}{counter:D4}";

                _logger.LogInformation("Generated order number {OrderNumber}", orderNumber);
                return orderNumber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Order number generation failed for date {Date}", today);
                throw;
            }
            finally
            {
                if (mustOpen)
                    _dataContext.Database.CloseConnection();
            }
        }
    }
}
