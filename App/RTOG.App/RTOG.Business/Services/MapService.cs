using Microsoft.EntityFrameworkCore;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;
using RTOG.Data.Persistence;
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
        public async Task<Map> Get(int lobbyID)
        {
            var map = _dbContext.Maps.Where(m => m.ID == lobbyID)
                                          .Include(m => m.AllTiles)
                                          .FirstOrDefault();

            if (map is null)
                throw new Exception("Map not found.");

            return map;
        }
    }
}
