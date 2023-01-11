using RTOG.Business.Infrastructure;
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
    internal class UnitService : IUnitService
    {
        private readonly AppDbContext _dbContext;
        public UnitService(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Unit> CreateUnit(Player player, string name)
        {

            var unit = player.Faction.CreateSolder(name);


            _dbContext.Units.Add(unit);
            await _dbContext.SaveChangesAsync();

            return unit;
        }
    }
}
