using Microsoft.AspNetCore.Mvc;

namespace RTOG.App.Controllers
{
    public class LobbyController : Controller
    {
        public IActionResult Lobby()
        {
            return View();
        }
    }
}
