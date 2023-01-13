using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RTOG.Data.Models
{
    public class Player : BaseEntity
    {
        [Required]
        [JsonIgnore]
        public Account PlayerAccount { get; set; }
        [Required]
        [JsonIgnore]
        public OngoingGame Game { get; set; }
        [Required]
        [JsonIgnore]
        public Faction Faction { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int TotalGold { get; set; }
        [Required]
        public List<Unit> AllMyUnits { get; set; }
        [Required]
        public List<Tile> OwnedTiles { get; set; }
    }
}
