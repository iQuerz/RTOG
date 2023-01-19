using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RTOG.App.Hubs
{
    public class LobbyHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task updateLobbyPlayers(string lobbyID)
        {
            await Clients.All.SendAsync("updateLobby", lobbyID);
        }

        public async Task startGame(string gameID)
        {
            await Clients.All.SendAsync("startGame", gameID);
        }
    }
}
