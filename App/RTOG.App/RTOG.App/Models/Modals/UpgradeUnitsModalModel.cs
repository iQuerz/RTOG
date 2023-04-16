using RTOG.Data.Models;

namespace RTOG.App.Models.Modals
{
    public class UpgradeUnitsModalModel
    {
        public int tileID { get; set; }
        public List<UnitUpgrade> Upgrades { get; set; }
    }
}
