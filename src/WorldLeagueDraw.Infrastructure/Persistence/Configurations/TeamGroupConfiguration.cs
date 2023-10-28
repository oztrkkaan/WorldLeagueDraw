using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeagueDraw.Domain.Entities;

namespace WorldLeagueDraw.Infrastructure.Persistence.Configurations
{
    public class TeamGroupConfiguration : IEntityTypeConfiguration<TeamGroup>
    {
        public void Configure(EntityTypeBuilder<TeamGroup> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.GroupId);
            builder.Property(m => m.TeamId);
            builder.Property(m => m.DrawId);
        }
    }
}
