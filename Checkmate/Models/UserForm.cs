using System.ComponentModel.DataAnnotations;
using static Checkmate.Entity.User;

namespace Checkmate.Models
{
    public class UserForm
    {
        [Required(ErrorMessage = "Le pseudo est obligatoire")]
        [StringLength(50, ErrorMessage = "Le pseudo ne peut pas dépasser 50 caractères")]
        public string Pseudo { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmation du mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Le genre est obligatoire")]
        public GenreType Genre { get; set; }

        [Range(0, 3000, ErrorMessage = "L'ELO doit être entre 0 et 3000")]
        public int? Elo { get; set; }
    }
}
