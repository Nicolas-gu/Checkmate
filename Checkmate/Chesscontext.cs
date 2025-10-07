using Checkmate.Entity;
using Microsoft.EntityFrameworkCore;

namespace Checkmate
{
    public class Chesscontext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
#if DEBUG
            modelBuilder.Entity<User>().HasData([
                new User { Id = 21, Username = "Nico", Email = "nico@chess.com", Password = "123456", Birthdate = new DateTime(1990, 11, 30), Genre = User.GenreType.Male, Elo = 2859, Role = User.RoleType.Admin },
                new User { Id = 1, Username = "MagnusCarlsen", Email = "magnus@chess.com", Password = "123456", Birthdate = new DateTime(1990, 11, 30), Genre = User.GenreType.Male, Elo = 2859, Role = User.RoleType.Player },
                new User { Id = 2, Username = "HikaruNakamura", Email = "hikaru@chess.com", Password = "123456", Birthdate = new DateTime(1987, 12, 9), Genre = User.GenreType.Male, Elo = 2787, Role = User.RoleType.Player },
                new User { Id = 3, Username = "DingLiren", Email = "ding@chess.com", Password = "123456", Birthdate = new DateTime(1992, 10, 24), Genre = User.GenreType.Male, Elo = 2780, Role = User.RoleType.Player },
                new User { Id = 4, Username = "IanNepomniachtchi", Email = "nepo@chess.com", Password = "123456", Birthdate = new DateTime(1990, 7, 14), Genre = User.GenreType.Male, Elo = 2770, Role = User.RoleType.Player },
                new User { Id = 5, Username = "FabianoCaruana", Email = "fabiano@chess.com", Password = "123456", Birthdate = new DateTime(1992, 7, 30), Genre = User.GenreType.Male, Elo = 2760, Role = User.RoleType.Player },
                new User { Id = 6, Username = "AlirezaFirouzja", Email = "firouzja@chess.com", Password = "123456", Birthdate = new DateTime(2003, 6, 18), Genre = User.GenreType.Male, Elo = 2750, Role = User.RoleType.Player },
                new User { Id = 7, Username = "JuditPolgar", Email = "judit@chess.com", Password = "123456", Birthdate = new DateTime(1976, 7, 23), Genre = User.GenreType.Female, Elo = 2735, Role = User.RoleType.Player },
                new User { Id = 8, Username = "HouYifan", Email = "hou@chess.com", Password = "123456", Birthdate = new DateTime(1994, 2, 27), Genre = User.GenreType.Female, Elo = 2658, Role = User.RoleType.Player },
                new User { Id = 9, Username = "BobbyFischer", Email = "fischer@chess.com", Password = "123456", Birthdate = new DateTime(1943, 3, 9), Genre = User.GenreType.Male, Elo = 2785, Role = User.RoleType.Player },
                new User { Id = 10, Username = "GarryKasparov", Email = "kasparov@chess.com", Password = "123456", Birthdate = new DateTime(1963, 4, 13), Genre = User.GenreType.Male, Elo = 2812, Role = User.RoleType.Player },               
                new User { Id = 11, Username = "ChessMaster42", Email = "cm42@chess.com", Password = "123456", Birthdate = new DateTime(1995, 5, 15), Genre = User.GenreType.Other, Elo = 2100, Role = User.RoleType.Player },
                new User { Id = 12, Username = "KnightRider", Email = "knight@chess.com", Password = "123456", Birthdate = new DateTime(1988, 8, 8), Genre = User.GenreType.Male, Elo = 1800, Role = User.RoleType.Player },
                new User { Id = 13, Username = "QueenSlayer", Email = "queen@chess.com", Password = "123456", Birthdate = new DateTime(1999, 12, 25), Genre = User.GenreType.Female, Elo = 1950, Role = User.RoleType.Player },
                new User { Id = 14, Username = "PawnStar", Email = "pawn@chess.com", Password = "123456", Birthdate = new DateTime(2000, 1, 1), Genre = User.GenreType.Male, Elo = 1200, Role = User.RoleType.Player },
                new User { Id = 15, Username = "RookAndRoll", Email = "rook@chess.com", Password = "123456", Birthdate = new DateTime(1993, 3, 3), Genre = User.GenreType.Other, Elo = 1600, Role = User.RoleType.Player },
                new User { Id = 16, Username = "TheStrategist", Email = "strategist@chess.com", Password = "123456", Birthdate = new DateTime(1985, 7, 7), Genre = User.GenreType.Male, Elo = 2000, Role = User.RoleType.Player },
                new User { Id = 17, Username = "BlitzQueen", Email = "blitz@chess.com", Password = "123456", Birthdate = new DateTime(1997, 6, 21), Genre = User.GenreType.Female, Elo = 1750, Role = User.RoleType.Player },
                new User { Id = 18, Username = "CheckmateKing", Email = "checkmate@chess.com", Password = "123456", Birthdate = new DateTime(1980, 11, 11), Genre = User.GenreType.Male, Elo = 2200, Role = User.RoleType.Player },
                new User { Id = 19, Username = "EndgameWizard", Email = "endgame@chess.com", Password = "123456", Birthdate = new DateTime(1992, 2, 2), Genre = User.GenreType.Male, Elo = 2300, Role = User.RoleType.Player },
                new User { Id = 20, Username = "OpeningGenius", Email = "opening@chess.com", Password = "123456", Birthdate = new DateTime(1998, 9, 9), Genre = User.GenreType.Other, Elo = 1900, Role = User.RoleType.Player }    
            ]);
#endif
        }
    }
}
