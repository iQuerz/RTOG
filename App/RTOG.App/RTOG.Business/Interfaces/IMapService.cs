using RTOG.Business.Infrastructure.Helper;
using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Interfaces
{
    public interface IMapService
    {
        public Task<Map> Get(int mapId);

        public Task<Map> GenerateMap(List<Point> points, int PlayerCount);
        public Task<MapPreset> GenerateMapPreset(List<Point> points);
        public Task<Map> GenerateMapFromPreset(int MapPresetID, int playerCount);
    }
}
