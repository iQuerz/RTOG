using Microsoft.EntityFrameworkCore;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;
using RTOG.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RTOG.Business.Services
{
    internal class UpgradeService : IUpgradeService
    {
        private readonly AppDbContext _dbContext;
        public UpgradeService(AppDbContext context)
        {
            _dbContext = context;
        }

        public List<UnitUpgrade> GetUpgradeOptions()
        {
            //bljak hardcoded values privremeno resenje popravice se nekada
            List<UnitUpgrade> unitUpgrades = new List<UnitUpgrade>()
            {
                new UnitUpgrade{ID = 1, Name = "WeaponUpgrade", Price = 20},
                new UnitUpgrade{ID = 2, Name = "ArmorUpgrade", Price = 20}
            };
          
            return unitUpgrades;
        }
        public string GetUpgradeName(int upgradeID)
        {
            switch (upgradeID)
            {
                case 1:
                    return "WeaponUpgrade";
                case 2:
                    return "ArmorUpgrade";
                default:
                    return"not a valid upgrade";
            }
        }
        public async Task UpgradeUnits(int UpgradeID, List<int> unitIDs)
        {
            List<Unit> units = _dbContext.Units
                                    .Include(u => u.Upgrades)
                                    .Where(u => unitIDs.Contains(u.ID))
                                    .ToList();

            //privremeno resenje nece biti hardoced kasnije
            switch (UpgradeID)
            {
                case 1:
                        foreach (var unit in units)
                        {
                            new WeaponUpgrade(unit);
                        }
                    break;
                case 2:
                        foreach (var unit in units)
                        {
                            new ArmorUpgrade(unit);
                        }
                    break;

                default:
                    Console.Write("not a valid upgrade");
                    break;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
