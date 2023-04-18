using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Interfaces
{
    public interface IUpgradeService
    {
        public List<UnitUpgrade> GetUpgradeOptions();

        public Task UpgradeUnits(int UpgradeID, List<int> unitIDs);

        public string GetUpgradeName(int upgradeID);
    }
}
