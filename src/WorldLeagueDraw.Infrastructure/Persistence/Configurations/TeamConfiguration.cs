using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeagueDraw.Domain.Entities;

namespace WorldLeagueDraw.Infrastructure.Persistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name);

            builder.HasOne(m => m.Country)
                .WithMany(m => m.Teams)
                .HasForeignKey(m=>m.CountryId);

            builder.HasMany(m => m.Groups)
                .WithMany(m => m.Teams)
                .UsingEntity<TeamGroup>();
        }
    }
}
