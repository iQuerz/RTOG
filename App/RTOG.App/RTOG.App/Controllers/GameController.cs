using Microsoft.AspNetCore.Mvc;
using RTOG.App.Models;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;

namespace RTOG.App.Controllers
{
    public class GameController : Controller
    {
        private readonly ILobbyService _lobbyService;
        private readonly IAccountService _accountService;
        private readonly IGameService _gameService;
        private readonly IMapService _mapService;

        public GameController(ILobbyService lobbyService,
                            IAccountService accountService,
                               IGameService gameService,
                                IMapService mapService)
        {
            _lobbyService = lobbyService;
            _accountService = accountService;
            _gameService = gameService;
            _mapService = mapService;
        }

        [Route("{api}/Game/{accountID}/{gameID}")]
        public async Task<IActionResult> Game(int accountID, int gameID)
        {
            var account = await _accountService.Get(accountID);
            var game = await _gameService.Get(gameID);

            var gameModel = new GameViewModel()
            {
                MyAccount = account,
                Game = game
            };

            return View("Game", gameModel);
        }

        [Route("{api}/Update")]
        public async Task<IActionResult> Update([FromBody] OngoingGame game)
        {

            await _gameService.Update(game);

            return Ok(game);
        }

        [Route("{api}/NextTurn/{gameID}")]
        public async Task<IActionResult> NextTurn(int gameID)
        {

            await _gameService.NextTurn(gameID);

            return Ok();
        }

        [HttpPost]
        [Route("{api}/CreateGame/{hostID}/{lobbyID}/{mapID}")]
        public async Task<IActionResult> CreateGame(int hostID, int lobbyID, int mapID)
        { 
            var lobby = await _lobbyService.Get(lobbyID);
            var map = await _mapService.GenerateMapFromPreset(mapID, lobby.Players.Count() + 1); //host je + 1

            if (lobby.Host.ID != hostID)
                throw new Exception("Only lobby hosts can start games.");

            var game = await _gameService.Create(lobby, map);
            return Ok(game);
        }
    }
}
