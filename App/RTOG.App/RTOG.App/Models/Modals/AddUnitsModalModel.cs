using RTOG.Data.Models;

namespace RTOG.App.Models.Modals
{
    public class AddUnitsModalModel
    {
        public int tileID { get; set; }
        public int playerID { get; set; }

        //legecy code je ovo units ali necu jos da obrisem dok ne potvrdim 100% da ovaj drugi nacin radi nemoj da me bijes
        public List<string> Units { get; set; }
        public List<Unit> UnitOptions { get; set; }
        
    }
}
