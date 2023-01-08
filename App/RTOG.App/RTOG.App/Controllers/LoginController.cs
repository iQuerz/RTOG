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

        [HttpPost]
        [Route("{api}/CreateGuest")]
        public async Task<IActionResult> CreateGuest(string guestUsername)
        {
            var guestAccount = await _accountService.CreateGuest(guestUsername);
            return Ok(guestAccount);
        }
    }
}
