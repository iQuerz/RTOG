using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class EdgePreset : BaseEntity
    {
        public Tile StartTile { get; set; }
        public Tile EndTile { get; set; }
    }
}
