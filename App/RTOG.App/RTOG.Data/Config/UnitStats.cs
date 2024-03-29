﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Config
{
    public class UnitStats
    {
        public static Dictionary<string, UnitConfig> Units { get; set; }

        public class UnitConfig
        {
            public string Name { get; set; }
            public int Attack { get; set; }
            public int Defense { get; set; }
            public int Health { get; set; }
            public int Price { get; set; }
            public int Movement { get; set; }
            public string Type { get; set; }
        }

        public UnitConfig this[string type]
        {
            get { return Units[type]; }
        }

        static UnitStats()
        {
            Units = new Dictionary<string, UnitConfig>();

            Units["AmericaSoldier"] = new UnitConfig
            {
                Name = "America Soldier",                
                Attack = 10,
                Defense = 5,
                Health = 50,
                Price = 110,
                Movement = 1,
                Type = "A-Soldier"
            };

            Units["AmericaTank"] = new UnitConfig
            {
                Name = "American Tank",
                Attack = 15,
                Defense = 6,
                Health = 90,
                Price = 200,
                Movement = 2,
                Type = "A-Tank"
            };

            Units["RussiaSoldier"] = new UnitConfig
            {
                Name = "Russia Soldier",
                Attack = 6,
                Defense = 10,
                Health = 60,
                Price = 90,
                Movement = 1,
                Type = "R-Soldier"
            };

            Units["RussiaTank"] = new UnitConfig
            {
                Name = "Russia Tank",
                Attack = 15,
                Defense = 10,
                Health = 110,
                Price = 170,
                Movement = 2,
                Type = "R-Tank"
            };
            Units["ChineseSoldier"] = new UnitConfig
            {
                Name = "Chinese Soldier",
                Attack = 7,
                Defense = 5,
                Health = 35,
                Price = 60,
                Movement = 1,
                Type = "C-Soldier"
            };
            Units["ChineseTank"] = new UnitConfig
            {
                Name = "Chinese Tank",
                Attack = 13,
                Defense = 5,
                Health = 90,
                Price = 130,
                Movement = 2,
                Type = "C-Tank"
            };
        }
    }
}
