using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace RTOG.Data.Models
{
    public class Account : BaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public bool IsGuest { get; set; }

        [Required]
        public DateTime LastActive { get; set; }

        [Required]
        public string SessionID { get; set; }

        [Required]
        public TimeSpan SessionDuration { get; set; }

        [AllowNull]
        public PlayerColor SelectedColor { get; set; }

        [ForeignKey("PlayerID")]
        public Player? Player { get; set; }

    }
}
