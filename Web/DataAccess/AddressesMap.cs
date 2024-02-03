using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models;

namespace Web.DataAccess
{
    public class AddressesMap : IEntityTypeConfiguration<Addresses>
    {
        public void Configure(EntityTypeBuilder<Addresses> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.City).HasColumnName("city").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Street).HasColumnName("street").HasMaxLength(50).IsRequired();
            builder.Property(x => x.HouseNumber).HasColumnName("house_number").HasMaxLength(50).IsRequired();
            builder.Property(x => x.FlatNumber).HasColumnName("flat_number").HasMaxLength(10).IsRequired();
            builder.ToTable("addresses", "public");
        }
    }
}
