using Microsoft.AspNetCore.Mvc;
using RTOG.App.Models;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;
using System.Diagnostics;

namespace RTOG.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILobbyService _lobbyService;

        public HomeController(ILogger<HomeController> logger,
                              ILobbyService lobbyService)
        {
            _logger = logger;
            _lobbyService = lobbyService;
        }
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> JoinLobby(Account account, string code)
        {
            var lobby = await _lobbyService.AddPlayerToLobby(account, code);
            var lobbyModel = new LobbyViewModel()
            {
                MyAccount = account,
                Lobby = lobby,
            };

            return View("Lobby", lobbyModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLobby(Account host)
        {
            var lobby = await _lobbyService.CreateLobby(host);
            var lobbyModel = new LobbyViewModel()
            {
                MyAccount = host,
                Lobby = lobby
            };

            return View("Lobby", lobbyModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}