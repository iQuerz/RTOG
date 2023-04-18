using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Interfaces
{
    public interface ILobbyService
    {
        public Task<Lobby> Get(int lobbyID);
        public Lobby GetByCode(string code);
        public Task<Lobby> AddPlayerToLobby(Account player, string code);
        public Task<Lobby> CreateLobby(Account host);
        public Task<bool> isPlayerInLobby(Account account, Lobby lobby);
    }
}
