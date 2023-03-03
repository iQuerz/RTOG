using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public abstract class Faction : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public List<Unit> Army { get; set; }

        [ForeignKey("PlayerID")]
        public Player Player { get; set; }

        public Faction(string name)
        {
            Name = name;
            Army = new List<Unit>();
            Player = new Player();
        }
        public Faction() { }
        public abstract Unit CreateSoldier(string name);
        public abstract Unit CreateTank(string name);
    }
}
