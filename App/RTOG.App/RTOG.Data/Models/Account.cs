using System.ComponentModel.DataAnnotations;

namespace RTOG.Data.Models
{
    public class Account : BaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public bool IsGuest { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public string SessionID { get; set; }

    }
}
