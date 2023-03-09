using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Interfaces
{
    public interface IGameService
    {
        public Task<OngoingGame> Get(int gameID);
        public Task<OngoingGame> Update(OngoingGame updatedGame);

        public Task<OngoingGame> Create(Lobby lobby, Map map);
    }
}
