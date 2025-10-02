using Checkmate.Entity;
using Checkmate.Utils;

namespace Checkmate.Models
{
    public class TournamentIndexModel(Tournament tournament)
    {
        public int Id { get; set; } = tournament.Id;
        public string Name { get; set; } = tournament.Name;
        public string? Place { get; set; } = tournament.Place ?? "Pas de lieu indiqué";
        //public int NbPlayer { get; set; } = tournament.
        public int MaxPlayer { get; set; } = tournament.MaxPlayer;
        public int MinPlayer { get; set; } = tournament.MinPlayer;
        public List<Tournament.CategoryType> Categories { get; set; } = tournament.Category.GetFlags();
        public int? MaxElo { get; set; } = tournament.MaxElo;
        public int? MinElo { get; set; } = tournament.MinElo;
        public Tournament.StatusType Status { get; set; } = tournament.Status;
        public DateTime CloseDate { get; set; } = tournament.CloseDate;
        public int CurrentRound { get; set; } = tournament.CurrentRound;
    }
}
