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
    public class ColorsService : IColorsService
    {
        private readonly AppDbContext _dbContext;
        public ColorsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PlayerColor> Get(int colorID)
        {
            var color = await _dbContext.PlayerColors.FindAsync(colorID);
            if(color == null) { throw new Exception("Color Not found"); }
            return color;
        }

        public List<PlayerColor> getColors()
        {
            return _dbContext.PlayerColors.ToList();
        }
    }
}
