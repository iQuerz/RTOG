using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

    }
}
