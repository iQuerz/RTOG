using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class MapPreset : BaseEntity
    {
        public string Name { get; set; }
        public List<TilePreset> Tiles { get; set; }
    }
}
