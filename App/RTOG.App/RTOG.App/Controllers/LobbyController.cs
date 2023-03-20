using Microsoft.AspNetCore.Mvc;
using RTOG.App.Models;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;
using System.Security.Cryptography.X509Certificates;

namespace RTOG.App.Controllers
{
    public class LobbyController : Controller
    {
        private readonly ILobbyService _lobbyService;
        private readonly IAccountService _accountService;
        private readonly IColorsService _colorsService;
        public LobbyController(ILobbyService lobbyService,
                             IAccountService accountService,
                              IColorsService colorsService)
        {
            _lobbyService = lobbyService;
            _accountService = accountService;
            _colorsService = colorsService;
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
                Lobby = lobby,
                PlayerColors = _colorsService.getColors()
            };
            return View("Lobby", lobbyModel);
        }

        [Route("{api}/LobbyPlayers/{accountID}/{lobbyID}")]
        public async Task<IActionResult> LobbyPlayers(int accountID, int lobbyID)
        {
            var account = await _accountService.Get(accountID);
            var lobby = await _lobbyService.Get(lobbyID);
            //todo:ako osoba ne postoji u lobby ne vracaj view

            var factions = new List<Faction>()
            {
                new AmericaFaction(),
                new ChineseFaction(),
                new RussiaFaction("")
            };

            var lobbyModel = new LobbyViewModel()
            {
                MyAccount = account,
                Lobby = lobby,
                PlayerColors = _colorsService.getColors() 
            };
            return View("LobbyPlayers", lobbyModel);
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

        [HttpPatch]
        [Route("{api}/UpdatePlayerColor/{accountID}/{lobbyID}/{colorID}")]
        public async Task<IActionResult> UpdatePlayerColor(int accountID, int lobbyID, int colorID)
        {
            var account = await _accountService.Get(accountID);
            var color = await _colorsService.Get(colorID);
            //var lobby = await _lobbyService.Get(lobbyID); //wanted to use this to check if player is inside the lobby

            await _accountService.UpdateColor(accountID, color);
            return Ok(account);
        }
    }
}
