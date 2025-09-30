using Microsoft.AspNetCore.Mvc;

namespace Checkmate.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
