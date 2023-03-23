using Microsoft.EntityFrameworkCore;
using RTOG.Business.Infrastructure;
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

        public async Task<OngoingGame> Create(Lobby lobby, Map map)
        {

            var game = new OngoingGame()
            {

                Players = new List<Player>(),
                Map = map,
                TurnCounter = 0

            };
            List<Account> players = lobby.Players;
            players.Add(lobby.Host);

            int turnOrderIncrement = 0;
            foreach (Account acc in players)
            {
                Player player = new Player()
                {
                    PlayerAccount = acc,
                    Game = game,
                    Faction = (Faction)Helpers.Factions[acc.SelectedFaction.Name]("Name"), //privremeno resenje dok ne izvucemo koj je faction iz lobija
                    Name = acc.Username, //redundandna infomacija ali da ne moramo da zovemo account u game vise
                    Color = acc.SelectedColor.Hex,
                    TotalGold = 0,
                    OwnedTiles = new List<Tile>(),
                    TurnOrder = turnOrderIncrement
                };
                turnOrderIncrement++;
                game.Players.Add(player);
                _dbContext.Players.Add(player);
            }
            //game.Players.Insert(0, lobby.Host.Player); //todo:mozda random redosled igraca idk


            _dbContext.Games.Add(game);
            _dbContext.Lobbies.Remove(lobby);
            await _dbContext.SaveChangesAsync();
            return game;
        }

        public async Task<OngoingGame> Get(int gameID)
        {
            var game = _dbContext.Games.Where(g => g.ID == gameID)
                                             .Include(g => g.Players)
                                             .Include(g => g.Map)
                                             .ThenInclude(m => m.AllTiles)
                                             .ThenInclude(t => t.Owner)
                                             .Include(g => g.Map)
                                             .ThenInclude(m => m.AllTiles)
                                             .ThenInclude(t => t.Units)
                                             .FirstOrDefault();

            if (game is null)
                throw new Exception("Game not found.");

            return game;
        }
        public async Task<OngoingGame> Update(OngoingGame updatedGame)
        {
            var game = _dbContext.Games.Where(g => g.ID == updatedGame.ID)
                                             .Include(g => g.Players)
                                             .Include(g => g.Map)
                                             .ThenInclude(m => m.AllTiles)
                                             .FirstOrDefault();

            game = updatedGame;

            if (game is null)
                throw new Exception("Game not found.");

            await _dbContext.SaveChangesAsync();

            return game;
        }
        public async Task<OngoingGame> NextTurn(int gameID)
        {
            var game = _dbContext.Games.Where(g => g.ID == gameID).FirstOrDefault();

            if (game is null)
                throw new Exception("Game not found.");

            game.TurnCounter++;

            await _dbContext.SaveChangesAsync();

            return game;
        }
    }
}
