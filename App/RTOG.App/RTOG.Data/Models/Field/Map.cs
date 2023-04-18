using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class Map : BaseEntity
    {
        public int PlayerCount { get; set; }
        public List<Tile> AllTiles { get; set; }

        public string getTilePercentageString(int tileNum)
        {
            double percentage = (double)tileNum / AllTiles.Count * 100;
            return Math.Round(percentage, 1).ToString() + "%";
        }
    }
}
