using Checkmate.Entity;
using Checkmate.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkmate.Controllers
{
    public class TournamentController(Chesscontext _db) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TournamentForm form)
        {
            if (ModelState.IsValid)
            {
                _db.Tournaments.Add(new Tournament
                {
                    Name = form.Name,
                    Place = form.Place,
                    MaxPlayer = form.MaxPlayer,
                    MinPlayer = form.MinPlayer,
                    MaxElo = form.MaxElo,
                    MinElo = form.MinElo,
                    Category = (Tournament.CategoryType)form.Category.Sum(),
                    WomenOnly = form.WomenOnly,
                    CloseDate = form.CloseDate
                });
                _db.SaveChanges();
                return RedirectToAction("Index", "Tournament");
            }
            TempData["error"] = "Invaid Data";
            return View();
        }
    }
}
