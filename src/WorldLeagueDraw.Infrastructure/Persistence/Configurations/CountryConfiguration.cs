using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldLeagueDraw.Domain.Entities;

namespace WorldLeagueDraw.Infrastructure.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name);

            builder.HasData(new Country("Türkiye"), 
                new Country("Almanya"), 
                new Country("Belçika"), 
                new Country("Fransa"), 
                new Country("Hollanda"), 
                new Country("Portekiz"), 
                new Country("İtalya"),
                new Country("İspanya"));
        }
    }
}
