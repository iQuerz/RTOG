using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RTOG.Data.Models
{
    public class UnitUpgrade : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Unit Unit { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
