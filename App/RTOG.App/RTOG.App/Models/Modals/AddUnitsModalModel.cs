using RTOG.Data.Models;

namespace RTOG.App.Models.Modals
{
    public class AddUnitsModalModel
    {
        public int tileID { get; set; }
        public int playerID { get; set; }
        public List<string> Units { get; set; }
        
    }
}
