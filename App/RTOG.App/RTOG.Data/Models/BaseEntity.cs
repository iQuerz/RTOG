using System.ComponentModel.DataAnnotations;

namespace RTOG.Data.Models
{
    public class BaseEntity
    {
        [Key] public int ID { get; set; }
    }
}
