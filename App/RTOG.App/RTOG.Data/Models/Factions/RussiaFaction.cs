using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class RussiaFaction : Faction
    {
        public RussiaFaction(string name) : base(name) { }

        public RussiaFaction() { }

        public override Unit CreateSoldier(string name)
        {
            var unit = new RussiaSoldier();
            unit.Name = name;
            Army.Add(unit);
            return unit;
        }

        public override Unit CreateTank(string name)
        {
            var unit = new RussiaTank();
            unit.Name = name;
            Army.Add(unit);
            return unit;
        }
    }
}
