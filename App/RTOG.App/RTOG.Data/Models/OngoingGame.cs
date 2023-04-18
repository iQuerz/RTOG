using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class OngoingGame : BaseEntity
    {
        [Required]
        public List<Player> Players { get; set; }
        [Required]
        public Map Map { get; set; }
        [Required]
        public int TurnCounter { get; set; }

        public bool IsPlaying(Player player) => TurnCounter % Map.PlayerCount == player.TurnOrder;
    }
}