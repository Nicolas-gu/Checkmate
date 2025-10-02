using System.ComponentModel.DataAnnotations;

namespace Checkmate.Entity
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Place { get; set; }
        public int MaxPlayer { get; set; }
        public int MinPlayer { get; set; }
        public int? MaxElo { get; set; }
        public int? MinElo { get; set; }
        public CategoryType Category { get; set; }
        public StatusType Status { get; set; }
        public int CurrentRound { get; set; } = 0;
        public bool WomenOnly { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime CloseDate { get; set; }
        public List<User> Registrations { get; set; }

        [Flags]
        public enum CategoryType
        {
            Junior = 1, Senior = 2, Veteran = 4
        }

        public enum StatusType
        {
            Waiting, InProgress, Finished
        }

    }
}
