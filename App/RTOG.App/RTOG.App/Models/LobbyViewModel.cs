using RTOG.Data.Models;

namespace RTOG.App.Models
{
    public class LobbyViewModel : BaseViewModel
    {
        public Lobby Lobby { get; set; }
        public List<PlayerColor> PlayerColors { get; set; }
    }
}
