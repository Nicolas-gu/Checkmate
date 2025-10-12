using Checkmate.Entity;
using Checkmate.Models;
using Checkmate.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Checkmate.Controllers
{
    public class TournamentController(Chesscontext _db) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var tournaments = _db.Tournaments
                .Include(t => t.Registrations).ToList()
                .Select(t => new TournamentIndexModel(t)).ToList();

            return View(tournaments);
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
                tournament.LastUpdateDate = DateTime.Now;
                return RedirectToAction("Index");
            }
            TempData["error"] = "Formulaire Invalide";
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var userIdClaim = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var uid) ? uid : 0;

            var tournament = _db.Tournaments
                .Include(t => t.Registrations)
                .FirstOrDefault(t => t.Id == id);

            if (tournament == null) return NotFound();

            ViewBag.IsUserRegistered = tournament.Registrations?.Any(u => u.Id == userIdClaim) ?? false;

            return View(tournament);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tournament = _db.Tournaments
                .Include(t => t.Registrations)
                .FirstOrDefault(t => t.Id == id);
            if (tournament == null)
            {
                return NotFound();
            }
            if (tournament.Status != Tournament.StatusType.Waiting)
            {
                TempData["error"] = "Impossible de supprimer un tournois en cours";
                return RedirectToAction("Detail", new { id = id });
            }
            if(tournament.Registrations != null)
            {
                tournament.Registrations.Clear();
            }
            _db.Tournaments.Remove(tournament);
            _db.SaveChanges();
            TempData["success"] = "Tournoi et inscriptions supprimés avec succès.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Register(int tournamentId)
        {
            var tournament = _db.Tournaments.Include(t => t.Registrations)
                .FirstOrDefault(t => t.Id == tournamentId);
            if (tournament == null)
            {
                return NotFound();
            }
            var userClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userClaim == null)
            {
                TempData["error"] = "Vous devez être connecté pour vous inscrire.";
                return RedirectToAction("Login");
            }
            int userId = int.Parse(userClaim);
            var user = _db.Users.Find(userId);
            if (user == null)
            {
                TempData["error"] = "Utilisateur introuvable";
                return RedirectToAction("Login");
            }
            if (tournament.Status != Tournament.StatusType.Waiting)
            {
                TempData["error"] = "Les inscriptions pour ce tournoi sont cloturées";
                return RedirectToAction("Detail", new { id = tournamentId });
            }
            if (tournament.WomenOnly)
            {
                if (user.Genre == Entity.User.GenreType.Male)
                {
                    TempData["error"] = "Tournoi interdit aux hommes";
                    return RedirectToAction("Detail", new { id = tournamentId });
                }
            }
            int age = (int)(tournament.CloseDate.Year - user.Birthdate.Year);
            if (age < 18)
            {
                if (!tournament.Category.HasFlag(Tournament.CategoryType.Junior))
                {
                    TempData["error"] = "Vous n'avez pas l'age requis pour participer à ce tournoi";
                    return RedirectToAction("Detail", new { id = tournamentId });
                }
            }
            if (age >= 18 && age < 60)
            {
                if (!tournament.Category.HasFlag(Tournament.CategoryType.Senior))
                {
                    TempData["error"] = "Vous n'avez pas l'age requis pour participer à ce tournoi";
                    return RedirectToAction("Detail", new { id = tournamentId });
                }
            }
            if ( age >= 60)
            {
                if (!tournament.Category.HasFlag(Tournament.CategoryType.Veteran))
                {
                    TempData["error"] = "Vous n'avez pas l'age requis pour participer à ce tournoi";
                    return RedirectToAction("Detail", new { id = tournamentId });
                }
            }
            
            if(user.Elo <= tournament.MinElo || user.Elo >= tournament.MaxElo)
            {
                TempData["error"] = "Votre Elo n'entre pas dans les conditions pour participer à ce tournoi";
                return RedirectToAction("Detail", new { id = tournamentId });
            }
            if(tournament.CloseDate <= DateTime.UtcNow)
            {
                TempData["error"] = "La date d'inscription est dépassée";
                return RedirectToAction("Detail", new { id = tournamentId });
            }
            if(tournament.NbPlayer >= tournament.MaxPlayer)
            {
                TempData["error"] = "Nombres de joueurs maximum atteint";
                return RedirectToAction("Detail", new { id = tournamentId });
            }
            
            if (tournament.Registrations == null)
            {
                tournament.Registrations = new List<User>();
            }
            if (!tournament.Registrations.Any(u => u.Id == user.Id))
            {
                tournament.Registrations.Add(user);
                tournament.NbPlayer = (tournament.NbPlayer ?? 0) + 1;
                _db.SaveChanges();
                TempData["success"] = "Inscription réussie !";
            }
            else
            {
                TempData["error"] = "Vous êtes déjà inscrit à ce tournoi";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UnRegister(int tournamentId)
        {
            var tournament = _db.Tournaments.Include(t => t.Registrations)
               .FirstOrDefault(t => t.Id == tournamentId);
            if (tournament == null)
            {
                return NotFound();
            }
            var userClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userClaim == null)
            {
                TempData["error"] = "Vous devez être connecté pour vous inscrire.";
                return RedirectToAction("Login");
            }
            int userId = int.Parse(userClaim);
            var user = _db.Users.Find(userId);
            if (user == null)
            {
                TempData["error"] = "Utilisateur introuvable";
                return RedirectToAction("Login");
            }
            if (tournament.Registrations != null && tournament.Registrations.Any(u => u.Id == user.Id))
            {
                if (tournament.Status != Tournament.StatusType.Waiting)
                {
                    TempData["error"] = "Impossible de se désinscrire d'un tournoi en cours";
                    return RedirectToAction("Detail", new { id = tournamentId });
                }
                tournament.Registrations.Remove(user);
                tournament.NbPlayer = (tournament.NbPlayer ?? 0) - 1;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult StartTournament(int id)
        {
            Tournament? tournament = _db.Tournaments.Find(id);
            if (tournament == null)
            {
                return NotFound();
            }
            //if (tournament.NbPlayer < tournament.MinPlayer)
            //{
            //    TempData["error"] = "Pas assez de joueurs";
            //    return RedirectToAction("Detail", new { id = id });
            //}
            //if (tournament.CloseDate > DateTime.Now)
            //{
            //    TempData["error"] = "La date de cloture des inscriptions n'est pas encore passée";
            //    return RedirectToAction("Detail", new { id = id });
            //}
            tournament.Status = Tournament.StatusType.InProgress;
            tournament.CurrentRound = 1;
            tournament.LastUpdateDate = DateTime.Now;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
