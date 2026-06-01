using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RajMango.Domain.Entities;

namespace RajMango.DataAccess.Configurations
{
    public class OrderTrackingHistoryConfiguration : IEntityTypeConfiguration<OrderTrackingHistory>
    {
        public void Configure(EntityTypeBuilder<OrderTrackingHistory> builder)
        {
            builder.HasIndex(x => x.OrderId)
                .HasDatabaseName("IX_OrderTrackingHistories_OrderId");

            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
