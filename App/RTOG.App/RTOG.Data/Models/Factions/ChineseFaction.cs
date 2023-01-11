using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class ChineseFaction : Faction
    {
        public ChineseFaction(string name) : base(name) { }

        public ChineseFaction() { }

        public override Unit CreateSoldier(string name)
        {
            var unit = new AmericaSoldier();
            unit.Name = name;
            Army.Add(unit);
            return unit;
        }

        public override Unit CreateTank(string name)
        {
            var unit = new AmericaTank();
            unit.Name = name;
            Army.Add(unit);
            return unit;
        }
    }
}
