using RTOG.Data.Models;

namespace RTOG.App.Models
{
    public class LobbyViewModel : BaseViewModel
    {
        public Lobby Lobby { get; set; }
        public List<PlayerColor> PlayerColors { get; set; }
        public List<Faction> Factions { get; set; }
        public List<MapPreset> MapPresets { get; set; }
        public List<FactionChoice> FactionChoices { get; set; }
    }
}
