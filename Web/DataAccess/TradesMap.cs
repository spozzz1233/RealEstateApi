using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.DataAccess
{
    public class TradesMap : IEntityTypeConfiguration<Trades>
    {
        public void Configure(EntityTypeBuilder<Trades> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired();
            builder.Property(x => x.AgentId).HasColumnName("agent_id").IsRequired();
            builder.Property(x => x.EstateID).HasColumnName("estate_id").IsRequired();
            builder.Property(x => x.Price).HasColumnName("price").IsRequired();

            builder.ToTable("trades", "public");
        }
    }
}