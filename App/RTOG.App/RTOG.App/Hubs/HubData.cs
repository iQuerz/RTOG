namespace RTOG.App.Hubs
{
    public static class HubData
    {
        public static Dictionary<string, List<string>> LobbyConnections { get; set; } = new Dictionary<string, List<string>>();

        private static Dictionary<string, List<string>> GameConnections { get; set; } = new Dictionary<string, List<string>>();

        //public HubData()
        //{
        //    LobbyConnections = new Dictionary<string, string>();
        //    GameConnections = new Dictionary<string, string>();
        //}
    }
}
