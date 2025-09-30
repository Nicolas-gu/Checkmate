using Microsoft.AspNetCore.Mvc;

namespace Checkmate.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
