using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RajMango.Domain.Entities;

namespace RajMango.DataAccess.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            //builder.HasOne(d => d.Order)
            //       .WithMany(o => o.OrderDetails)
            //       .HasForeignKey(d => d.OrderId)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
