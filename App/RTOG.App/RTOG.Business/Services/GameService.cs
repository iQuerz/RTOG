using RTOG.Business.Interfaces;
using RTOG.Data.Models;
using RTOG.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _dbContext;
        public GameService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OngoingGame> Create(Lobby lobby)
        {
            var game = new OngoingGame()
            {
                Players = lobby.Players,
            };
            game.Players.Insert(0, lobby.Host); //todo:mozda random redosled igraca idk

            _dbContext.Games.Add(game);
            _dbContext.Lobbies.Remove(lobby);
            await _dbContext.SaveChangesAsync();
            return game;
        }

        public async Task<OngoingGame> Get(int gameID)
        {
            var game = await _dbContext.Games.FindAsync(gameID);

            if (game is null)
                throw new Exception("Game not found.");

            return game;
        }
    }
}
