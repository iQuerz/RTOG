
namespace RTOG.Data.Models
{
    public class Lobby : BaseEntity
    {
        public string Code { get; set; }
        public Account Host { get; set; }
        public List<Account> Players { get; set; }

        //treba se doda ali necu dodam jos da ne sjebem model 
        //public Map SelectedMap { get; set; }
    }
}
