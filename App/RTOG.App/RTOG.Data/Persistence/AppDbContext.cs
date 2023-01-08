using Microsoft.EntityFrameworkCore;

using RTOG.Data.Models;

namespace RTOG.Data.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<OngoingGame> Games { get; set; }

    }
}
