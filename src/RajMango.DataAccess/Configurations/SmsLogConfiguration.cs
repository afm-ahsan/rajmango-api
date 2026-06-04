using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RajMango.Domain.Entities;

namespace RajMango.DataAccess.Configurations
{
    public class SmsLogConfiguration : IEntityTypeConfiguration<SmsLog>
    {
        public void Configure(EntityTypeBuilder<SmsLog> builder)
        {
            builder.HasIndex(x => x.OrderNumber)
                .HasDatabaseName("IX_SmsLogs_OrderNumber");

            builder.HasIndex(x => new { x.UserId, x.Status })
                .HasDatabaseName("IX_SmsLogs_UserId_Status");

            builder.HasIndex(x => x.CreatedAt)
                .HasDatabaseName("IX_SmsLogs_CreatedAt");
        }
    }
}
