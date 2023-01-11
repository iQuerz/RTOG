using Microsoft.EntityFrameworkCore;

using RTOG.Data.Models;
using RTOG.Data.Models.Field;

namespace RTOG.Data.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<OngoingGame> Games { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<AmericaFaction> AmericaFactions { get; set; }
        public DbSet<ChineseFaction> ChineseFactions { get; set; }
        public DbSet<RussiaFaction> RussiaFactions { get; set; }
        public DbSet<UnitUpgrade> UnitUpgrades { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Tile> Tiles { get; set; }
        public DbSet<Edge> Edges { get; set; }

    }
}
