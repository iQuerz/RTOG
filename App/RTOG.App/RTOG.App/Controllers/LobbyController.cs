using Microsoft.AspNetCore.Mvc;
using RTOG.App.Models;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;

namespace RTOG.App.Controllers
{
    public class LobbyController : Controller
    {
        private readonly ILobbyService _lobbyService;
        private readonly IAccountService _accountService;
        public LobbyController(ILobbyService lobbyService,
                             IAccountService accountService)
        {
            _lobbyService = lobbyService;
            _accountService = accountService;
        }

        [Route("{api}/Lobby/{accountID}/{lobbyID}")]
        public async Task<IActionResult> Lobby(int accountID, int lobbyID)
        {
            var account = await _accountService.Get(accountID);
            var lobby = await _lobbyService.Get(lobbyID);
            //todo:ako osoba ne postoji u lobby ne vracaj view

            var lobbyModel = new LobbyViewModel()
            {
                MyAccount = account,
                Lobby = lobby
            };
            return View("Lobby", lobbyModel);
        }

        [HttpPost]
        [Route("{api}/CreateLobby/{accountID}")]
        public async Task<IActionResult> CreateLobby(int accountID)
        {
            var host = await _accountService.Get(accountID);
            var lobby = await _lobbyService.CreateLobby(host);

            return Ok(lobby);
        }

        [HttpPut]
        [Route("{api}/JoinLobby/{accountID}/{lobbyCode}")]
        public async Task<IActionResult> JoinLobby(int accountID, string lobbyCode)
        {
            var account = await _accountService.Get(accountID);
            var lobby = await _lobbyService.AddPlayerToLobby(account, lobbyCode);

            return Ok(lobby);
        }

    }
}
