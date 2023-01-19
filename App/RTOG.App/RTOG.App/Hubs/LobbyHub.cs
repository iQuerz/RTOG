using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RTOG.App.Hubs
{
    public class LobbyHub : Hub
    {
        public async Task updateLobbyPlayers(string lobbyID)
        {
            await Clients.All.SendAsync("updateLobby", lobbyID);
        }
    }
}
