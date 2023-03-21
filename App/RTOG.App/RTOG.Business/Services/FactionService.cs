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
    public class FactionService : IFactionService
    {
        private readonly AppDbContext _dbContext;
        public FactionService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<FactionChoice> GetChoice(int factionID)
        {
            var faction = await _dbContext.FactionChoices.FindAsync(factionID);
            if (faction == null) { throw new Exception("Faction Not found"); }
            return faction;
        }
        public async Task<List<FactionChoice>> GetAllFactions()
        {

            return await _dbContext.FactionChoices.ToListAsync();
        }
    }
}
