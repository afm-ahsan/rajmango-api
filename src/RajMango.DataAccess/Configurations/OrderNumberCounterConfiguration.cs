using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RajMango.Domain.Entities;

namespace RajMango.DataAccess.Configurations
{
    public class OrderNumberCounterConfiguration : IEntityTypeConfiguration<OrderNumberCounter>
    {
        public void Configure(EntityTypeBuilder<OrderNumberCounter> builder)
        {
            builder.HasKey(x => x.Date);
            builder.Property(x => x.Date).HasColumnType("date");
            builder.Property(x => x.Counter).IsRequired();
        }
    }
}
