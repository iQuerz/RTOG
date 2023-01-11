using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public abstract class Faction : BaseEntity
    {
        protected string Name { get; set; }
        public List<Unit> Army { get; set; }
        public Player Player { get; set; }

        public Faction(string name)
        {
            this.Name = name;
            Army = new List<Unit>();
        }
        public abstract Unit CreateSolder(string name);
        public abstract Unit CreateTank(string name);
    }
}
