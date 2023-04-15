using Microsoft.EntityFrameworkCore;
using RTOG.Business.Infrastructure;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;
using RTOG.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RTOG.Business.Services
{
    internal class UnitService : IUnitService
    {
        private readonly AppDbContext _dbContext;
        public UnitService(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<List<Unit>> CreateUnit(int playerID, string name, int tileID, List<string> unitsToCreate)
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

            List<Unit> units = new ();

            Type factionType = player.Faction.GetType();
            MethodInfo[] methods = factionType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            foreach (string unitToCreate in unitsToCreate)
            {
                foreach (MethodInfo method in methods)
                {
                    if (method.Name.Contains(unitToCreate))
                    {
                        var unit = (Unit)method.Invoke(player.Faction, new object[] { name });

                        _dbContext.Units.Add(unit);

                        faction.Army.Add(unit);

                        tile.Units.Add(unit);

                        units.Add(unit);
                    }

                }
            }

            if (tile.Owner == null)
                tile.Owner = player;

            await _dbContext.SaveChangesAsync();

            return units;


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

        public async Task<List<string>> GetUnitsOptions(int playerID)
        {
            var player = _dbContext.Players.Where(p => p.ID == playerID)
                                          .Include(p => p.Faction)
                                          .FirstOrDefault();

            if (player is null)
                throw new Exception("Player not found.");

            Type factionType = player.Faction.GetType();
            MethodInfo[] methods = factionType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            var unitOptions = new List<string>();
            foreach (MethodInfo method in methods)
            {
                unitOptions.Add(method.Name);
            }
            return unitOptions;
        }
    }

}
