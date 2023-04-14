using Microsoft.EntityFrameworkCore;
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
        public async Task<Unit> CreateUnit(int playerID, string name, int tileID, string unitType)
        {
            var player = _dbContext.Players.Where(p => p.ID == playerID)
                                          .Include(p => p.Faction)
                                          .FirstOrDefault();

            if (player is null)
                throw new Exception("Player not found.");

            var tile = _dbContext.Tiles.Where(t => t.ID == tileID)
                                        .Include(p => p.Units)
                                        .FirstOrDefault();

            if (tile is null)
                throw new Exception("Tile not found.");

            var faction = _dbContext.Factions.Where(f => f.ID == player.Faction.ID)
                                .FirstOrDefault();

            if (faction is null)
                throw new Exception("Faction not found.");

            var unit = new Unit();

            if (unitType == "Tank")
            {
                unit = player.Faction.CreateTank(name);
            }
            else //default ponasanje
            {
                unit = player.Faction.CreateSoldier(name);
            }
            

            _dbContext.Units.Add(unit);

            faction.Army.Add(unit);

            tile.Units.Add(unit);

            if (tile.Owner == null)
                tile.Owner = player;

            await _dbContext.SaveChangesAsync();

            Console.WriteLine(unit.ID);
            Console.WriteLine(unit.Name);
            return unit;
           
            
        }

        public async Task<List<Unit>> GetUnits(int tileID)
        {

            var tile = _dbContext.Tiles.Where(t => t.ID == tileID)
                                        .Include(p => p.Units)
                                        .FirstOrDefault();

            if (tile is null)
                throw new Exception("Tile not found.");

            //mozda nepotrebno ovo dole videcemo jos
            if (tile.Units is null)
                throw new Exception("Tile has no units.");

            return tile.Units;
        }
    }

    
}
