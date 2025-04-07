using Basis.Domain.Aggregates.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.Infrastructure.Data.EntityConfiguration
{
    public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.Zipcode)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.Complement)
                .HasMaxLength(250);

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(a => a.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(a => a.DeletedAt)
                .HasDefaultValue(null)
                .ValueGeneratedNever();

            builder.HasQueryFilter(a => !a.DeletedAt.HasValue);

            builder.HasOne(a => a.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CustomerId);
        }
    }
}
