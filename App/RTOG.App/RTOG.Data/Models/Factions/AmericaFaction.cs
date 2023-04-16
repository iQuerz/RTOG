using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class AmericaFaction : Faction
    {
        public AmericaFaction(string name) : base(name) 
        {
            UnitOptions = new Dictionary<Type, Func<string, Unit>>
            {
                { typeof(AmericaSoldier), name => CreateSoldier(name) },
                { typeof(AmericaTank), name => CreateTank(name) }
            };
        }

        public AmericaFaction() 
        {
            UnitOptions = new Dictionary<Type, Func<string, Unit>>
            {
                { typeof(AmericaSoldier), name => CreateSoldier(name) },
                { typeof(AmericaTank), name => CreateTank(name) }
            };
        }

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
