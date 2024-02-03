using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccess
{
    public class OwnersMap : IEntityTypeConfiguration<Owners>
    {
        public void Configure(EntityTypeBuilder<Owners> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.OwnerName).HasColumnName("owner_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.OwnerSurName).HasColumnName("owner_surname").HasMaxLength(50).IsRequired();
            builder.Property(x => x.OwnerMidName).HasColumnName("owner_midname").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.DateOfBirth).HasColumnName("date_of_birth").IsRequired();
            builder.Property(x => x.Phonenum).HasColumnName("phonenum").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Passport).HasColumnName("passport").HasMaxLength(10).IsRequired();
            builder.ToTable("owners", "public");
        }
    }
}
