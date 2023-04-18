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
        private readonly IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger,
                                      IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("{api}/Guest/{guestUsername}")]
        public async Task<IActionResult> Guest(string guestUsername)
        {
            var guestAccount = await _accountService.CreateGuest(guestUsername);

            var homeModel = new HomeViewModel()
            {
                MyAccount = guestAccount,
            };
            return View("Home", homeModel);
        }

        [Route("{api}/Home/{accountID}")]
        public async Task<IActionResult> Home(int accountID)
        {
            var account = await _accountService.Get(accountID);

            var homeModel = new HomeViewModel()
            {
                MyAccount = account
            };

            return View(homeModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}