using Microsoft.EntityFrameworkCore;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;
using RTOG.Data.Persistence;
using RTOG.Business.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Services
{
    internal class MapService : IMapService
    {
        private readonly AppDbContext _dbContext;
        public MapService(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Map> Get(int mapID)
        {
            var map = _dbContext.Maps.Where(m => m.ID == mapID)
                                          .Include(m => m.AllTiles)
                                          .FirstOrDefault();


            if (map is null)
                throw new Exception("Map not found.");

            return map;
        }
        public async Task<Map> GenerateMap(List<Point> points, int playerCount)
        {
            var random = new Random();
            var map = new Map()
            {
                PlayerCount = playerCount,
                AllTiles = new List<Tile>()

            };


            _dbContext.Maps.Add(map);
            //_dbContext.SaveChanges();

            foreach (Point p in points)
            {
                var tile = new Tile()
                {
                    PositionX = p.x,
                    PositionY = p.y,
                    Gold = random.Next(10, 90),
                    Map = map,
                    Owner = null,
                    Units = null,
                };
                map.AllTiles.Add(tile);
                _dbContext.Tiles.Add(tile);
                
            }
            _dbContext.SaveChanges();
            return map;
        }

    }
}
