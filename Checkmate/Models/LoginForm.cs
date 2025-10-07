using System.ComponentModel.DataAnnotations;

namespace Checkmate.Models
{
    public class LoginForm
    {
        [Required(ErrorMessage = "Entrez un nom d'utilisateur")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Entrez un mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
