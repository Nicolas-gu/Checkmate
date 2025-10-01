using Checkmate.Entity;
using Checkmate.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkmate.Controllers
{
    public class UserController(Chesscontext _db) : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserForm form)
        {
            // sauver dans la db
            if(ModelState.IsValid)
            {
                if(_db.Users.Any(u => u.Pseudo == form.Pseudo || _db.Users.Any(u => u.Email == form.Email)))
                {

                    // TODO ajouter message d'erreur dans la vue
                    TempData["error"] = "Invaid Email or Pseudo";
                    return View();
                }
                _db.Users.Add(new User
                {
                    Pseudo = form.Pseudo,
                    Email = form.Email,
                    Birthdate = form.Birthdate,
                    Elo = form.Elo ?? 1200,
                    Password = form.Password,
                    Genre = form.Genre,
                    Role = Entity.User.RoleType.Player,
                });
                _db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            // TODO afficher dans le main layout 
            TempData["error"] = "Invaid Data";
            return View();
        }
    }
}
