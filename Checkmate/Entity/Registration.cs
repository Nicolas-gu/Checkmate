using System.ComponentModel.DataAnnotations;

namespace Checkmate.Entity
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime RegistredAt { get; set; }
        public bool isCancelled { get; set; }
        public DateTime? CancelledAt { get; set; }
    }
}
