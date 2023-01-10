using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class Tile : BaseEntity
    {
        public Player Owner { get; set; }
        public List<Tile> Neighbors { get; set; }
        public List<Unit> Units { get; set; }
        public Map Map { get; set; }
        public int Gold { get; set; }
        public float PositionY { get; set; }
        public float PositionX { get; set; }
    }
}
