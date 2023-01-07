using Microsoft.AspNetCore.Mvc;
using RTOG.App.Models;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;

namespace RTOG.App.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [Route("{api}/LoginGuest/{guestUsername}")]
        public async Task<IActionResult> LoginGuest(string guestUsername)
        {
            var guestAccount = await _accountService.CreateGuest(guestUsername);

            var homeModel = new HomeViewModel()
            {
                MyAccount = guestAccount,
            };
            return View("~/Views/Home/Home.cshtml", homeModel);
        }
    }
}
