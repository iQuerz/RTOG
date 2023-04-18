using Microsoft.EntityFrameworkCore;

using RTOG.Data.Models;

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

        public DbSet<PlayerColor> PlayerColors { get; set; }
        public DbSet<FactionChoice> FactionChoices { get; set; }

        public DbSet<MapPreset> MapPresets { get; set; }
        public DbSet<TilePreset> TilePresets { get; set; }
        public DbSet<EdgePreset> EdgePresets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerColor>().HasData(
                new PlayerColor
                {
                    ID = 2,
                    Hex = "#650101",
                    Name = "Dark Red"
                },
                new PlayerColor
                {
                    ID = 3,
                    Hex = "#006E33",
                    Name = "Forest Green"
                },
                new PlayerColor
                {
                    ID = 4,
                    Hex = "#ADD8E6",
                    Name = "Light Blue"
                },
                new PlayerColor
                {
                    ID = 5,
                    Hex = "#000080",
                    Name = "Navy Blue"
                },
                new PlayerColor
                {
                    ID = 6,
                    Hex = "#7851a9",
                    Name = "Royal Purple"
                },
                new PlayerColor
                {
                    ID = 7,
                    Hex = "#68331C",
                    Name = "Royal Brown"
                }
            );
            modelBuilder.Entity<FactionChoice>().HasData(
                new FactionChoice
                {
                    ID = 1,
                    Name = "America"
                },
                new FactionChoice
                {
                    ID = 2,
                    Name = "China"
                },
                new FactionChoice
                {
                    ID = 3,
                    Name = "Russia"
                }
            );
        }
    }
}
