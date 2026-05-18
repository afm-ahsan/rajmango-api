using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RajMango.Domain.Entities;

namespace RajMango.DataAccess.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasOne(f => f.Order)
                   .WithMany(o => o.Feedbacks)
                   .HasForeignKey(f => f.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // You can add more config here if needed (e.g. indexes, defaults)
        }
    }
}
