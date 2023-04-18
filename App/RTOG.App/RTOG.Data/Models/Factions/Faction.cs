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

        [NotMapped]
        public Dictionary<Type, Func<string, Unit>> UnitOptions { get; set; }
        //public List<Type> UnitOptions { get; set; }

        [ForeignKey("PlayerID")]
        public Player Player { get; set; }

        public Faction(string name)
        {
            Name = name;
            Army = new List<Unit>();
            Player = new Player();
            //UnitOptions= new List<Type>();
            UnitOptions = new Dictionary<Type, Func<string, Unit>>();
        }
        public Faction() {
            Army= new List<Unit>();
            UnitOptions = new Dictionary<Type, Func<string, Unit>>();
            //UnitOptions = new List<Type>();
        }
        public abstract Unit CreateSoldier(string name);
        public abstract Unit CreateTank(string name);
    }
}
