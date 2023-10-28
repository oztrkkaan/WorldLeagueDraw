using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeagueDraw.Domain.Entities;

namespace WorldLeagueDraw.Infrastructure.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.GroupName);

            builder.HasMany(m => m.Draws)
                .WithMany(m => m.Groups)
                .UsingEntity<DrawGroup>();

        }
    }
}
