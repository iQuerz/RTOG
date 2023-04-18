using Microsoft.EntityFrameworkCore;
using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Interfaces
{
    public interface IFactionService
    {
        public Task<FactionChoice> GetChoice(int factionID);
        public Task<List<FactionChoice>> GetAllFactions();

    }
}
