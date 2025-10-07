using Checkmate.Entity;
using Checkmate.Models;
using Checkmate.Utils;
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
            User? user = _db.Users.FirstOrDefault(u => u.Username == form.Username);
            if (user != null && PasswordUtils.Verify(user.Password, form.Password))
            {

                return RedirectToAction("Index", "Tournament");
            }

            TempData["error"] = "Nom d'utilisateur ou mot de passe invalide!";
            return View();
        }
    }
}

