using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTOG.Data.Config;

namespace RTOG.Data.Models
{
    internal class ArmorUpgrade : UnitUpgrade
    {
        public ArmorUpgrade(Unit unit) : base(unit, "ArmorUpgrade")
        {
            Unit.Defense = Unit.Defense + UpgradeStats.Upgrades["ArmorUpgrade"].UpgradeValue;
        }
    }
}
