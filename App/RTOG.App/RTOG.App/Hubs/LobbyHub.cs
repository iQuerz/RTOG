using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;

namespace RTOG.App.Hubs
{
    public class LobbyHub : Hub
    {
        //private HubData _hubData { get; set; }
        //public LobbyHub(HubData hubData)
        //{
        //    _hubData= hubData;
        //}

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //var connections = HubData.LobbyConnections.Where(c => c.Value.Remove(Context.ConnectionId)).FirstOrDefault();
            //await updateLobbyPlayers(connections.Key);
        }

        public async Task registerConnection(string lobbyID)
        {
            List<string> connectionIDs;
            if(!HubData.LobbyConnections.TryGetValue(lobbyID, out connectionIDs))
            {
                connectionIDs = new List<string>();
                connectionIDs.Add(Context.ConnectionId);
                HubData.LobbyConnections.Add(lobbyID,connectionIDs);
            }
            else
            {
                connectionIDs.Add(Context.ConnectionId);
            }
        }

        public async Task updateLobbyPlayers(string lobbyID)
        {
            var connections = HubData.LobbyConnections[lobbyID];

            foreach (var connection in connections)
            {
                await Clients.Client(connection).SendAsync("updateLobby");
            }
        }

        public async Task startGame(string gameID)
        {
            var connections = HubData.LobbyConnections.Where(c => c.Value.Contains(Context.ConnectionId)).FirstOrDefault().Value;

            foreach(var connection in connections)
            {
                await Clients.Client(connection).SendAsync("connectToGame", gameID);
            }
        }
    }
}
