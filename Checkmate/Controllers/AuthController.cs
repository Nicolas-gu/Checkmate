using Checkmate.Entity;
using Checkmate.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkmate.Controllers
{
    public class AuthController(Chesscontext _db) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            User? user = _db.Users.FirstOrDefault(u => u.Pseudo == form.Username);


            TempData["error"] = "Invalid Credentials";
            return View();
        }
    }
}
