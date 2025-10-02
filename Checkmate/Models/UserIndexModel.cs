using static Checkmate.Entity.User;

namespace Checkmate.Models
{
    public class UserIndexModel
    {
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public GenreType Genre { get; set; }
        public int? Elo { get; set; }
    }
}
