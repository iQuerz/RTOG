using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Config
{
    public class UpgradeStats
    {
        public static Dictionary<string, UpgradeConfig> Upgrades { get; set; }

        public class UpgradeConfig
        {
            public int Price { get; set; }
            public int UpgradeValue { get; set; }
        }
        public UpgradeConfig this[string type]
        {
            get { return Upgrades[type]; }
        }
        static UpgradeStats()
        {
            Upgrades = new Dictionary<string, UpgradeConfig>();

            Upgrades["WeaponUpgrade"] = new UpgradeConfig
            {
                Price = 20,
                UpgradeValue = 10
            };

            Upgrades["ArmorUpgrade"] = new UpgradeConfig
            {
                Price = 20,
                UpgradeValue = 10
            };

            Upgrades["MovmentUpgrade"] = new UpgradeConfig
            {
                Price = 20,
                UpgradeValue = 5
            };
        }
    }
}
