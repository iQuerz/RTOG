using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class Unit : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Attack { get; set; }
        [Required]
        public int Defense { get; set; }
        [Required]
        public int Health { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Movement { get; set; }
        [Required]
        public Tile MyTile { get; set; }
        [Required]
        public Faction MyFaction { get; set; }
        [Required]
        public Player MyPlayer { get; set; }
        public List<UnitUpgrade> Upgrades { get; set; }
    }
}
