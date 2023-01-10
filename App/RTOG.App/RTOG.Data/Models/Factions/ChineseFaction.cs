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

        public override Unit CreateSolder(string name)
        {
            var unit = new AmericaSolder();
            unit.Name = name;
            army.Add(unit);
            return unit;
        }

        public override Unit CreateTank(string name)
        {
            var unit = new AmericaTank();
            unit.Name = name;
            army.Add(unit);
            return unit;
        }
    }
}
