using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Checkmate.Entity
{
    [Index("Email", IsUnique = true)]
    [Index("Pseudo", IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public GenreType Genre { get; set; }
        public int? Elo { get; set; }
        public RoleType Role { get; set; }
        public List<Tournament> Registrations { get; set; }
        public enum GenreType
        {
            Male, Female, Other
        }
        public enum RoleType
        {
            Admin, Player
        }
    }
}
