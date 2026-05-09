using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RajMango.Domain.Entities;

namespace RajMango.DataAccess.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            //builder.HasOne(p => p.Order)
            //       .WithMany()
            //       .HasForeignKey(p => p.OrderId)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
