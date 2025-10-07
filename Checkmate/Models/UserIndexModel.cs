using Checkmate.Entity;
using static Checkmate.Entity.User;

namespace Checkmate.Models
{
    public class UserIndexModel(User user)
    {
        public int Id { get; set; } = user.Id;
        public string Username { get; set; } = user.Username;
        public string Email { get; set; } = user.Email;
        public DateTime Birthdate { get; set; } = user.Birthdate;
        public GenreType Genre { get; set; } = user.Genre;
        public int? Elo { get; set; } = user?.Elo;
        public RoleType Role { get; set; } = user.Role;
        public List<Tournament> Registrations { get; set; } = user.Registrations;
    }
}
