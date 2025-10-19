using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkmate.Entity
{
    public class Encounter
    {
        [Key]
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int WhitePlayerId { get; set; }
        public int BlackPlayerId { get; set; }

        [ForeignKey(nameof(WhitePlayerId))]
        public User? WhitePlayer { get; set; }

        [ForeignKey(nameof(BlackPlayerId))]
        public User? BlackPlayer { get; set; }
        public int Round { get; set; }
        public Result Results { get; set; }

        public enum Result
        {
            White, Black, Par, NotPlayedYet
        }
    }
}
