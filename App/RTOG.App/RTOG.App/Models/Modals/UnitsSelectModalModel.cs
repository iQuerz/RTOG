using RTOG.Data.Models;

namespace RTOG.App.Models.Modals
{
    public class UnitsSelectModalModel
    {
        public int tileID { get; set; }
        public int upgradeID { get; set; }
        public List<Unit> Units { get; set; }
    }
}
