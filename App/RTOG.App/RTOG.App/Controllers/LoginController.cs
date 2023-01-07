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
        public async Task<IActionResult> LoginGuest(Account guestAccount)
        {
            //todo:pozovi servis sacuvaj guest
            //guestAccount = _accountService.createGuest(guestAccount);
            var homeModel = new HomeViewModel()
            {
                MyAccount = guestAccount,
            };
            return View("Home", homeModel);
        }
    }
}
