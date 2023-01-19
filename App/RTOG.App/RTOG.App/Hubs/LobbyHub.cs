using Microsoft.AspNetCore.SignalR;

namespace RTOG.App.Hubs
{
    public class LobbyHub : Hub
    {
        private HubData _hubData { get; set; }
        public LobbyHub()
        {
            _hubData = HubData.Instance;
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //var connections = HubData.LobbyConnections.Where(c => c.Value.Remove(Context.ConnectionId)).FirstOrDefault();
            //await updateLobbyPlayers(connections.Key);
        }

        public async Task registerConnection(string lobbyID)
        {
            List<string> connectionIDs;
            if(!_hubData.LobbyConnections.TryGetValue(lobbyID, out connectionIDs))
            {
                connectionIDs = new List<string>();
                connectionIDs.Add(Context.ConnectionId);
                _hubData.LobbyConnections.Add(lobbyID,connectionIDs);
            }
            else
            {
                connectionIDs.Add(Context.ConnectionId);
            }
        }

        public async Task updateLobbyPlayers(string lobbyID)
        {
            var connections = _hubData.LobbyConnections[lobbyID];

            foreach (var connection in connections)
            {
                await Clients.Client(connection).SendAsync("updateLobby");
            }
        }

        public async Task startGame(string gameID)
        {
            var connections = _hubData.LobbyConnections.Where(c => c.Value.Contains(Context.ConnectionId)).FirstOrDefault().Value;

            foreach(var connection in connections)
            {
                await Clients.Client(connection).SendAsync("connectToGame", gameID);
            }
        }
    }
}
