using RTOG.Data.Models;
using RTOG.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Services
{
    internal class PlayerService
    {
        private readonly AppDbContext _dbContext;
        public PlayerService(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Player> Create()
        {

            // to be implemented
            var player = new Player();

            return player;
        }
    }
}
