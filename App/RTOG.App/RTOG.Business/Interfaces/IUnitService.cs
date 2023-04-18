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
        public Task<List<Unit>> CreateUnit(int playerID, string name, int tileID, List<string> unitType);
        public Task<List<Unit>> CreateUnitV2(int playerID, string name, int tileID, List<Unit> unitType);

        public Task<List<Unit>> GetUnits(int tileID);

        public Task<List<string>> GetUnitsOptions(int playerID);
        public Task<List<Unit>> GetUnitsOptionsV2(int playerID);

        public Task MoveUnits(List<int> unitIDs, int tileStartID, int tileEndID);
    }
}
