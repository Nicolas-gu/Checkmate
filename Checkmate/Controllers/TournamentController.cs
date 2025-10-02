using Checkmate.Entity;
using Checkmate.Models;
using Checkmate.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Checkmate.Controllers
{
    public class TournamentController(Chesscontext _db) : Controller
    {
        public IActionResult Index()
        {
            return View(_db.Tournaments.Select(t => new TournamentIndexModel(t)).ToList());
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
                if(form.CloseDate < DateTime.Now.AddDays(form.MaxPlayer))
                {
                    ModelState.AddModelError("CloseDate", "La date doit etre plus grande que " + DateTime.Now.AddDays(form.MaxPlayer));
                    return View();
                }

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
                    CloseDate = form.CloseDate,
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                });
                _db.SaveChanges();
                return RedirectToAction("Index", "Tournament");
            }
            TempData["error"] = "Invaid Data";
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Tournament? tournament = _db.Tournaments.Find(id);
            return View(new TournamentForm
            {
                Name = tournament.Name,
                Place = tournament.Place,
                MaxPlayer = tournament.MaxPlayer,
                MinPlayer = tournament.MinPlayer,
                MaxElo = tournament.MaxElo,
                MinElo = tournament.MinElo,
                Category = tournament.Category.GetFlags().Cast<int>().ToList(),
                WomenOnly = tournament.WomenOnly,
                CloseDate = tournament.CloseDate,
            });
        }
        
        [HttpPost]
        public IActionResult Edit(int id, TournamentForm form)
        {
            Tournament? tournament = _db.Tournaments.Find(id);
            if (ModelState.IsValid)
            {
                tournament.Name = form.Name;
                tournament.Place = form.Place;
                tournament.MaxPlayer = form.MaxPlayer;
                tournament.MinPlayer = form.MinPlayer;
                tournament.MaxElo = form.MaxElo;
                tournament.MinElo = form.MinElo;
                tournament.Category = (Tournament.CategoryType)form.Category.Sum();
                tournament.WomenOnly = form.WomenOnly;
                tournament.LastUpdateDate = DateTime.Now;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["error"] = "Formulaire Invalide";
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_db.Tournaments.Find(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Tournament? tournament = _db.Tournaments.Find(id);
            if(tournament == null)
            {
                return NotFound();
            }
            _db.Tournaments.Remove(tournament);
            _db.SaveChanges();  // ne pas oublier les changements sur la db apres la suppression
            return RedirectToAction("Index");
        }
    }
}
