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

        public Lobby GetByCode(string code)
        {
            var lobby = _dbContext.Lobbies.Where(l => l.Code == code).FirstOrDefault();

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
                Code = Helpers.GetRandomString() //todo:neka code bude unique
            };

            _dbContext.Lobbies.Add(lobby);
            await _dbContext.SaveChangesAsync();

            return lobby;
        }

    }
}
