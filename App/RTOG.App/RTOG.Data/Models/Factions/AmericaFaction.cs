using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class AmericaFaction : Faction
    {
        public AmericaFaction(string name) : base(name) { }

        public override Unit CreateSolder(string name)
        {
            var unit = new AmericaSolder();
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
