using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class Tile : BaseEntity
    {
        
        public Player? Owner { get; set; }

        [NotMapped]
        public List<Tile> Neighbors { get; set; }

        public List<Unit>? Units { get; set; }

        [Required]
        [JsonIgnore]
        public Map Map { get; set; }

        [Required]
        public int Gold { get; set; }

        [Required]
        public float PositionY { get; set; }

        [Required]
        public float PositionX { get; set; }
    }
}
