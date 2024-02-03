using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models;

namespace Web.DataAccess
{
    public class AgentsMap : IEntityTypeConfiguration<Agents>
    {
        public void Configure(EntityTypeBuilder<Agents> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn().IsRequired();
            builder.Property(x => x.AgentName).HasColumnName("agent_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.AgentSurName).HasColumnName("agent_surname").HasMaxLength(50).IsRequired();
            builder.Property(x => x.AgentMidName).HasColumnName("agent_midname").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.DateOfBirth).HasColumnName("date_of_birth").IsRequired();
            builder.Property(x => x.Phonenum).HasColumnName("phonenum").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Passport).HasColumnName("passport").HasMaxLength(10).IsRequired();
            builder.ToTable("agents", "public");
        }
    }
}
