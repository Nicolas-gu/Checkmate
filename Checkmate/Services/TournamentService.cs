using Checkmate.Entity;
using Microsoft.EntityFrameworkCore;

namespace Checkmate.Services
{
    public class TournamentService(Chesscontext _db)
    {
        public void GenerateEncounter(int tournamentId)
        {
            // charge le tournoi avec ses joueurs
            var tournament = _db.Tournaments
                .Include(t => t.Registrations)
                .FirstOrDefault(t =>  t.Id == tournamentId);

            if (tournament == null || tournament.Registrations == null || tournament.Registrations.Count < 2)
            {
                return;
            }
            // ajoute a une liste
            var players = tournament.Registrations.ToList();
            int nbPlayers = players.Count;
            bool isPair = false;

            // si impair -> add joueur fictif
            if (nbPlayers % 2 != 0)
            {
                players.Add(new User { Id = -1, Username = "BYE" });
                nbPlayers++;
                isPair = true;
            }

            int nbRounds = nbPlayers - 1;
            var encounters = new List<Encounter>();
            

            for (int round = 1; round <= nbRounds; round++)
            {
                for (int i = 0; i < nbPlayers / 2; i++)
                {
                    var white = players[i];
                    var black = players[nbPlayers - 1 - i];

                    if( white.Id == -1 || black.Id == -1)
                    {
                        continue;
                    }

                    encounters.Add(new Encounter
                    {
                        TournamentId = tournamentId,
                        WhitePlayerId = white.Id,
                        BlackPlayerId = black.Id,
                        Round = round,
                        Results = Encounter.Result.NotPlayedYet
                    });
                }

                var last = players[nbPlayers - 1];
                players.RemoveAt(nbPlayers - 1);
                players.Insert(1, last);
            }

            for(int round = 1; round <= nbRounds; round++)
            {
                foreach (var match in encounters.Where(e => e.Round == round).ToList())
                {
                    encounters.Add(new Encounter
                    {
                        TournamentId = tournamentId,
                        WhitePlayerId = match.BlackPlayerId,
                        BlackPlayerId = match.WhitePlayerId,
                        Round = round + nbRounds,
                        Results = Encounter.Result.NotPlayedYet
                    });
                }
            }

            _db.Encounters.AddRange(encounters);
            
        }

        public (bool Succes, string Message) RegisterPlayer(int tournamentId, int userId)
        {
            var tournament = _db.Tournaments.Include(t => t.Registrations)
                .FirstOrDefault(t => t.Id == tournamentId);
            if (tournament == null)
            {
                return (false, "Aucun tournoi trouvé");
            }
            var user = _db.Users.Find(userId);
            if (user == null)
            {
                return (false, "Aucun joueur trouvé");
            }
            if (tournament.Status != Tournament.StatusType.Waiting)
            {
                return (false, "Les inscriptions pour ce tournoi sont cloturées");
            }
            if (tournament.WomenOnly)
            {
                if (user.Genre == Entity.User.GenreType.Male)
                {
                    return (false, "Tournoi interdit aux hommes");
                }
            }
            int age = (int)(tournament.CloseDate.Year - user.Birthdate.Year);
            if (age < 18)
            {
                if (!tournament.Category.HasFlag(Tournament.CategoryType.Junior))
                {
                    return (false, "Vous n'avez pas l'age requis pour participer à ce tournoi");
                }
            }
            if (age >= 18 && age < 60)
            {
                if (!tournament.Category.HasFlag(Tournament.CategoryType.Senior))
                {
                    return (false, "Vous n'avez pas l'age requis pour participer à ce tournoi");
                }
            }
            if (age >= 60)
            {
                if (!tournament.Category.HasFlag(Tournament.CategoryType.Veteran))
                {
                    return (false, "Vous n'avez pas l'age requis pour participer à ce tournoi");
                }
            }

            if (user.Elo <= tournament.MinElo || user.Elo >= tournament.MaxElo)
            {
                return (false, "L'elo n'entre pas dans les conditions pour participer à ce tournoi");
            }
            if (tournament.CloseDate <= DateTime.UtcNow)
            {
                return (false, "La date d'inscription est dépassée");
            }
            if (tournament.NbPlayer >= tournament.MaxPlayer)
            {
                return (false, "Nombres de joueurs maximum atteint");
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
                return (true, "Inscription réussie !");
            }
            else
            {
                return (false, "Déjà inscrit à ce tournoi");
            }
            
        }

    }
}
