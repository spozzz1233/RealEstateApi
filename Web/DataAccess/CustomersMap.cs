using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccess
{
    public class CustomersMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.CustomerName).HasColumnName("customer_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.CustomerSurname).HasColumnName("customer_surname").HasMaxLength(50).IsRequired();
            builder.Property(x => x.CustomerMidName).HasColumnName("customer_midname").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.DateOfBirth).HasColumnName("date_of_birth").IsRequired();
            builder.Property(x => x.Phonenum).HasColumnName("phonenum").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Passport).HasColumnName("passport").HasMaxLength(10).IsRequired();
            builder.ToTable("customers", "public");
        }
    }
}
