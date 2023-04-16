using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class RussiaFaction : Faction
    {
        public RussiaFaction(string name) : base(name) 
        {
            UnitOptions = new Dictionary<Type, Func<string, Unit>>
            {
                { typeof(RussiaSoldier), name => CreateSoldier(name) },
                { typeof(RussiaTank), name => CreateTank(name) }
            };
        }

        public RussiaFaction() 
        {
            UnitOptions = new Dictionary<Type, Func<string, Unit>>
            {
                { typeof(RussiaSoldier), name => CreateSoldier(name) },
                { typeof(RussiaTank), name => CreateTank(name) }
            };
        }

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
