using Microsoft.EntityFrameworkCore;
using RTOG.Business.Infrastructure;
using RTOG.Business.Interfaces;

using RTOG.Data.Models;
using RTOG.Data.Persistence;

namespace RTOG.Business.Services
{
    public class LobbyService : ILobbyService
    {
        private readonly AppDbContext _dbContext;
        public LobbyService(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Lobby> Get(int lobbyID)
        {
            var lobby = _dbContext.Lobbies.Where(l => l.ID == lobbyID)
                                          .Include(l => l.Host)
                                          .ThenInclude(p => p.SelectedColor)
                                          .Include(l => l.Host)
                                          .ThenInclude(l => l.SelectedFaction)
                                          .Include(l => l.Players)
                                          .ThenInclude(p => p.SelectedColor)
                                          .Include(l => l.Players)
                                          .ThenInclude(p => p.SelectedFaction)
                                          .FirstOrDefault();

            if (lobby is null)
                throw new Exception("Lobby not found.");

            return lobby;
        }
        public Lobby GetByCode(string code)
        {
            var lobby = _dbContext.Lobbies.Where(l => l.Code == code)
                                          .Include(l => l.Host)
                                          .Include(l=> l.Players)
                                          .FirstOrDefault();

            if (lobby is null)
                throw new Exception("Lobby not found."); //todo:static string u sred koda = no no

            return lobby;
        }

        public async Task<Lobby> AddPlayerToLobby(Account player, string code)
        {
            var lobby = GetByCode(code);

            //todo: prvo izbaci istog playera iz drugih lobbies ako moze
            lobby.Players.Add(player);

            await _dbContext.SaveChangesAsync();

            return lobby;
        }

        public async Task<Lobby> CreateLobby(Account host)
        {
            var lobby = new Lobby
            {
                Host = host,
                Players = new(),
                Code = Helpers.GetRandomString(6) //todo:neka code bude unique
            };

            _dbContext.Lobbies.Add(lobby);
            await _dbContext.SaveChangesAsync();

            return lobby;
        }

        public Task<bool> isPlayerInLobby(Account account, Lobby lobby)
        {
            throw new NotImplementedException();
        }
    }
}
