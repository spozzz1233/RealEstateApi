using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccess
{
    public class RealEstatesMap : IEntityTypeConfiguration<RealEstates>
    {
        public void Configure(EntityTypeBuilder<RealEstates> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.OwnerId).HasColumnName("owner_id").IsRequired();
            builder.Property(x => x.AddressId).HasColumnName("address_id").IsRequired();
            builder.Property(x => x.TypeOfEstate).HasColumnName("type_of_estate").HasMaxLength(50).IsRequired();
            builder.Property(x => x.EstateQuantity).HasColumnName("estate_quantity").IsRequired();

            builder.ToTable("real_estates", "public");
        }
    }
}