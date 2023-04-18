using Microsoft.AspNetCore.SignalR;

namespace RTOG.App.Hubs
{
    public class GameHub : Hub
    {
        private HubData _hubData { get; set; }
        public GameHub()
        {
            _hubData = HubData.Instance;
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //var connections = HubData.LobbyConnections.Where(c => c.Value.Remove(Context.ConnectionId)).FirstOrDefault();
            //await updateLobbyPlayers(connections.Key);
        }

        public async Task registerConnection(string gameID)
        {
            List<string> connectionIDs;
            if (!_hubData.GameConnections.TryGetValue(gameID, out connectionIDs))
            {
                connectionIDs = new List<string>();
                connectionIDs.Add(Context.ConnectionId);

                _hubData.GameConnections.Add(gameID, connectionIDs);
            }
            else
            {
                connectionIDs.Add(Context.ConnectionId);
            }
        }

        public async Task updateGamePlayers(string gameID)
        {
            var connections = _hubData.GameConnections[gameID];

            foreach (var connection in connections)
            {
                await Clients.Client(connection).SendAsync("updateGame");
            }
        }

        public async Task finishGame(string gameID)
        {
            var connections = _hubData.GameConnections[gameID];

            foreach (var connection in connections)
            {
                await Clients.Client(connection).SendAsync("finishGame");
            }
        }
    }
}
