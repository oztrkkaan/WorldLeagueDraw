using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WorldLeagueDraw.Application.Interfaces;
using WorldLeagueDraw.Domain.Entities;

namespace WorldLeagueDraw.Infrastructure.Persistence.Context
{
    public class WorldLeagueDrawDbContext : DbContext, IWorldLeagueDrawDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamGroup> TeamGroups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<DrawGroup> DrawGroup { get; set; }

        public WorldLeagueDrawDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
