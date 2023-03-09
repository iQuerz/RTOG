using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Interfaces
{
    public interface IUnitService
    {
        public Task<Unit> CreateUnit(int playerID, string name, int tileID);
    }
}
