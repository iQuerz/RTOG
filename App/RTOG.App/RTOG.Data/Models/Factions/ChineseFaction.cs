using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class ChineseFaction : Faction
    {
        public ChineseFaction(string name) : base(name) 
        {
            UnitOptions = new Dictionary<Type, Func<string, Unit>>
            {
                { typeof(ChineseSoldier), name => CreateSoldier(name) },
                { typeof(ChineseTank), name => CreateTank(name) }
            };
        }

        public ChineseFaction() 
        {
            UnitOptions = new Dictionary<Type, Func<string, Unit>>
            {
                { typeof(ChineseSoldier), name => CreateSoldier(name) },
                { typeof(ChineseTank), name => CreateTank(name) }
            };
        }

        public override Unit CreateSoldier(string name)
        {
            var unit = new ChineseSoldier();
            unit.Name = name;
            Army.Add(unit);
            return unit;
        }

        public override Unit CreateTank(string name)
        {
            var unit = new ChineseTank();
            unit.Name = name;
            Army.Add(unit);
            return unit;
        }
    }
}
