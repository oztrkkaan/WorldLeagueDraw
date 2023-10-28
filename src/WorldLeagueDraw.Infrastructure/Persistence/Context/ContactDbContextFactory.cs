using Microsoft.EntityFrameworkCore;

namespace WorldLeagueDraw.Infrastructure.Persistence.Context
{
    public class ContactDbContextFactory : DesignTimeDbContextFactoryBase<WorldLeagueDrawDbContext>
    {
        protected override WorldLeagueDrawDbContext CreateNewInstance(DbContextOptions<WorldLeagueDrawDbContext> options)
        {
            return new WorldLeagueDrawDbContext(options);
        }
    }
}
