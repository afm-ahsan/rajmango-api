using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RajMango.Domain.Entities;

namespace RajMango.DataAccess.Configurations
{
    public class CourierRateConfigurationConfiguration : IEntityTypeConfiguration<CourierRateConfiguration>
    {
        public void Configure(EntityTypeBuilder<CourierRateConfiguration> builder)
        {
            // Only one active rate per provider + location type
            builder.HasIndex(x => new { x.CourierProviderId, x.CourierLocationType })
                .IsUnique()
                .HasFilter("[IsActive] = 1")
                .HasDatabaseName("UX_CourierRateConfigurations_Provider_LocationType_Active");

            builder.HasOne(x => x.CourierProvider)
                .WithMany(p => p.CourierRateConfigurations)
                .HasForeignKey(x => x.CourierProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.RatePerKg).HasPrecision(18, 4);
            builder.Property(x => x.MinimumCharge).HasPrecision(18, 2);
        }
    }
}
