using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RajMango.Domain.Entities;

namespace RajMango.DataAccess.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Nullable FK — existing customers without an app account remain valid
            builder.HasOne(c => c.AppUser)
                   .WithMany()
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);
        }
    }
}
