using System.ComponentModel.DataAnnotations;
using static Checkmate.Entity.Tournament;

namespace Checkmate.Models
{
    public class TournamentForm
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        public string Place { get; set; }

        [Required(ErrorMessage = "Le nombre minimum de joueur est obligatoire")]
        [Range(2, 32, ErrorMessage = "Le nombre minimum de joueur doit être comprit entre 2 et 32")]
        public int MinPlayer { get; set; }
        
        [Required(ErrorMessage = "Le nombre maximum de joueur est obligatoire")]
        [Range(2, 32, ErrorMessage = "Le nombre maximum de joueur doit être comprit entre 2 et 32")]
        public int MaxPlayer { get; set; }

        [Range(0, 3000, ErrorMessage = "L'elo doit être compris entre 0 et 3000")]
        public int MinElo { get; set; }

        [Range(0, 3000, ErrorMessage = "L'elo doit être compris entre 0 et 3000")]
        public int MaxElo {  get; set; }

        [Required(ErrorMessage = "Choisissez au moins une catégorie")]
        public List<int> Category { get; set; }

        [Required(ErrorMessage = "Choisissez une option")]
        public bool WomenOnly { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Entrez une date limite pour les inscriptions")]
        public DateTime CloseDate { get; set; }
    }
}
