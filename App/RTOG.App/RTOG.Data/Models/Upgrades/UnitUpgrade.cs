using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTOG.Data.Config;


namespace RTOG.Data.Models
{
    public class UnitUpgrade : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Unit Unit { get; set; }
        [Required]
        public int Price { get; set; }

        public UnitUpgrade(Unit unit, string type)
        {
            Price = UpgradeStats.Upgrades[type].Price;
            Name = type;
            Unit = unit;
            Unit.Upgrades.Add(this);
        }
        public UnitUpgrade() { }
    }

}

