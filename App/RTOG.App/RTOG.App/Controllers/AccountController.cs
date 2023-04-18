using Microsoft.AspNetCore.Mvc;

namespace RTOG.App.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
