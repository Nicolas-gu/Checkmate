using Checkmate.Entity;
using Checkmate.Utils;

namespace Checkmate.Models
{
    public class TournamentDetailModel(Tournament tournament)
    {
        public int Id { get; set; } = tournament.Id;
        public string Name { get; set; } = tournament.Name;
        public string? Place { get; set; } = tournament.Place ?? "Pas de lieu indiqué";
        public int? NbPlayer { get; set; } = tournament.NbPlayer;
        public List<User>? Registrations { get; set; } = tournament.Registrations.ToList();
        public List<Tournament.CategoryType> Categories { get; set; } = tournament.Category.GetFlags();
        public int? MaxElo { get; set; } = tournament.MaxElo;
        public int? MinElo { get; set; } = tournament.MinElo;
        public Tournament.StatusType Status { get; set; } = tournament.Status;
        public DateTime CloseDate { get; set; } = tournament.CloseDate;
        public int CurrentRound { get; set; } = tournament.CurrentRound;
    }
}
