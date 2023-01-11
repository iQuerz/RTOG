using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTOG.Data.Config;

namespace RTOG.Data.Models
{
    internal class WeaponUpgrade : UnitUpgrade
    {
        public WeaponUpgrade(Unit unit) : base(unit, "WeaponUpgrade")
        {
            Unit.Attack = Unit.Attack + UpgradeStats.Upgrades["WeaponUpgrade"].UpgradeValue;
        }
    }
}
