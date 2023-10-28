using Microsoft.EntityFrameworkCore;
using WorldLeagueDraw.Domain.Entities;

namespace WorldLeagueDraw.Application.Interfaces
{
    public interface IWorldLeagueDrawDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamGroup> TeamGroups { get; set; }
        public DbSet<DrawGroup> DrawGroup { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public Task<int> SaveChangesAsync();
    }
}
