using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeagueDraw.Domain.Entities;

namespace WorldLeagueDraw.Infrastructure.Persistence.Configurations
{
    public class DrawConfiguration : IEntityTypeConfiguration<Draw>
    {
        public void Configure(EntityTypeBuilder<Draw> builder)
        {
            builder.HasKey(m => m.UId);
            builder.Property(m => m.CreatorFullName);
        }
    }
}
