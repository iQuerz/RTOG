using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTOG.Data.Models
{
    public class Player : BaseEntity
    {
        [Required]
        public Account PlayerAccount { get; set; }
        [Required]
        public OngoingGame Game { get; set; }
        [Required]
        public Faction Faction { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TotalGold { get; set; }
        [Required]
        public int GoldPerTurn { get; set; }
        [Required]
        public List<Unit> AllMyUnits { get; set; }
        [Required]
        public List<Tile> OwnedTiles { get; set; }
    }
}
