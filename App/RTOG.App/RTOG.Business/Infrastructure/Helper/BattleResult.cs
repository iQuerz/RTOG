using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Infrastructure.Helper
{
    internal class BattleResult
    {
        public List<Unit> RemainingUnitsAttacker { get; set; }
        public List<Unit> RemainingUnitsDeffender { get; set; }
        public int Status { get; set; }

    }
}
