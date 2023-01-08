using Microsoft.AspNetCore.Mvc;
using RTOG.App.Models;
using RTOG.Business.Interfaces;

namespace RTOG.App.Controllers
{
    public class GameController : Controller
    {
        private readonly ILobbyService _lobbyService;
        private readonly IAccountService _accountService;
        private readonly IGameService _gameService;

        public GameController(ILobbyService lobbyService,
                            IAccountService accountService,
                               IGameService gameService)
        {
            _lobbyService = lobbyService;
            _accountService = accountService;
            _gameService = gameService;
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

        [HttpPost]
        [Route("{api}/CreateGame/{hostID}/{lobbyID}")]
        public async Task<IActionResult> CreateGame(int hostID, int lobbyID)
        {
            var lobby = await _lobbyService.Get(lobbyID);

            if (lobby.Host.ID != hostID)
                throw new Exception("Only lobby hosts can start games.");

            var game = await _gameService.Create(lobby);
            return Ok(game);
        }
    }
}
