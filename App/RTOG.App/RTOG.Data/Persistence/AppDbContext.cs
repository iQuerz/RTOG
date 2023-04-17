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
                    ID = 1,
                    Hex = "#fff",
                    Name = "White"
                },
                new PlayerColor
                {
                    ID = 2,
                    Hex = "#f33",
                    Name = "Red"
                },
                new PlayerColor
                {
                    ID = 3,
                    Hex = "#3f3",
                    Name = "Green"
                },
                new PlayerColor
                {
                    ID = 4,
                    Hex = "#33f",
                    Name = "Blue"
                },
                new PlayerColor
                {
                    ID = 5,
                    Hex = "#ff3",
                    Name = "Yellow"
                },
                new PlayerColor
                {
                    ID = 6,
                    Hex = "#f3f",
                    Name = "Magenta"
                },
                new PlayerColor
                {
                    ID = 7,
                    Hex = "#3ff",
                    Name = "Cyan"
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
