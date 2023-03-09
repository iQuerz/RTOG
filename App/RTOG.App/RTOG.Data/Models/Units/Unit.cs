using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RTOG.Data.Config;

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
        //[Required]
        //[JsonIgnore]
        //public Tile Tile { get; set; }
        //[Required]
        //public Faction? Faction { get; set; }
        public List<UnitUpgrade> Upgrades { get; set; }
        protected Unit(string type)
        {

            Name = UnitStats.Units[type].Name;
            Attack = UnitStats.Units[type].Attack;
            Defense = UnitStats.Units[type].Defense;
            Health = UnitStats.Units[type].Health;
            Price = UnitStats.Units[type].Price;
            Movement = UnitStats.Units[type].Movement;
            Upgrades = new List<UnitUpgrade>();
            //Tile = new Tile();
            
        }

        public Unit() { }
    }
}
