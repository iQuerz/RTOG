namespace RTOG.App.Hubs
{
    public sealed class HubData
    {
        HubData()
        {
            LobbyConnections = new Dictionary<string, List<string>>();
            GameConnections = new Dictionary<string, List<string>>();
        }
        private static readonly object _lock = new object();
        private static HubData _instance = null;
        public static HubData Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new HubData();
                    }
                    return _instance;
                }
            }
        }


        public Dictionary<string, List<string>> LobbyConnections { get; set; }

        public Dictionary<string, List<string>> GameConnections { get; set; }
    }
}