using Checkmate.Entity;
using Checkmate.Models;
using Checkmate.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Checkmate.Controllers
{
    public class UserController(Chesscontext _db) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Users.Select(u => new UserIndexModel(u)).ToList());
        }

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
                if(_db.Users.Any(u => u.Username == form.Username))
                {
                    TempData["error"] = "Nom d'utilisateur déjà utilisé";
                    return View();
                }
                if(_db.Users.Any(u => u.Email == form.Email))
                {
                    TempData["error"] = "Email déjà utilisé";
                    return View();
                }
                _db.Users.Add(new User
                {
                    Username = form.Username,
                    Email = form.Email,
                    Birthdate = form.Birthdate,
                    Elo = form.Elo ?? 1200,
                    Password = PasswordUtils.Hash(form.Password),
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
