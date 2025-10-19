using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Checkmate.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPlayer = table.Column<int>(type: "int", nullable: false),
                    MinPlayer = table.Column<int>(type: "int", nullable: false),
                    NbPlayer = table.Column<int>(type: "int", nullable: true),
                    MaxElo = table.Column<int>(type: "int", nullable: true),
                    MinElo = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CurrentRound = table.Column<int>(type: "int", nullable: false),
                    WomenOnly = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Elo = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encounters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    WhitePlayerId = table.Column<int>(type: "int", nullable: false),
                    BlackPlayerId = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    Results = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encounters_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentUser",
                columns: table => new
                {
                    RegistrationsId = table.Column<int>(type: "int", nullable: false),
                    RegistrationsId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentUser", x => new { x.RegistrationsId, x.RegistrationsId1 });
                    table.ForeignKey(
                        name: "FK_TournamentUser_Tournaments_RegistrationsId",
                        column: x => x.RegistrationsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentUser_Users_RegistrationsId1",
                        column: x => x.RegistrationsId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Category", "CloseDate", "CreationDate", "CurrentRound", "LastUpdateDate", "MaxElo", "MaxPlayer", "MinElo", "MinPlayer", "Name", "NbPlayer", "Place", "Status", "WomenOnly" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2800, 32, 1600, 8, "Open International de Paris", 0, "Paris", 0, false },
                    { 2, 2, new DateTime(2025, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2400, 16, 1200, 4, "Championnat Féminin de Lyon", 0, "Lyon", 0, true },
                    { 3, 2, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200, 20, 1000, 6, "Blitz d’Hiver de Lille", 0, "Lille", 0, false },
                    { 4, 1, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600, 12, 800, 4, "Tournoi Jeunes Espoirs", 0, "Marseille", 0, false },
                    { 5, 6, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2600, 24, 1500, 8, "Grand Prix de Bordeaux", 0, "Bordeaux", 0, false },
                    { 6, 2, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2400, 20, 1300, 6, "Open Mixte de Toulouse", 0, "Toulouse", 0, false },
                    { 7, 1, new DateTime(2025, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1400, 16, 0, 4, "Tournoi des Rookies", 0, "Nantes", 0, false },
                    { 8, 2, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2600, 32, 1400, 10, "Championnat de Bretagne", 0, "Rennes", 0, false },
                    { 9, 3, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200, 20, 1100, 4, "Open Féminin de Nice", 0, "Nice", 0, true },
                    { 10, 2, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2600, 28, 1500, 12, "Tournoi Rapide du Capitole", 0, "Toulouse", 0, false },
                    { 11, 6, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2800, 32, 1600, 12, "Festival Échecs de Cannes", 0, "Cannes", 0, false },
                    { 12, 1, new DateTime(2025, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2100, 24, 1000, 6, "Open Universitaire de Grenoble", 0, "Grenoble", 0, false },
                    { 13, 2, new DateTime(2025, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, 16, 1000, 8, "Coupe des Dames", 0, "Strasbourg", 0, true },
                    { 14, 4, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, 20, 1300, 8, "Tournoi de la Montagne Noire", 0, "Carcassonne", 0, false },
                    { 15, 1, new DateTime(2025, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500, 16, 800, 6, "Championnat Régional Jeunes", 0, "Dijon", 0, false },
                    { 16, 4, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2800, 20, 1500, 8, "Tournoi des Légendes", 0, "Reims", 0, false },
                    { 17, 3, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, 32, 1300, 10, "Open de Printemps", 0, "Angers", 0, false },
                    { 18, 2, new DateTime(2025, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200, 16, 1100, 4, "Blitz Féminin de Montpellier", 0, "Montpellier", 0, true },
                    { 19, 6, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2700, 28, 1500, 12, "Open National d’Été", 0, "La Rochelle", 0, false },
                    { 20, 1, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600, 20, 800, 6, "Open Juniors du Nord", 0, "Lille", 0, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthdate", "Elo", "Email", "Genre", "Password", "Role", "Username", "isDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2859, "magnus@chess.com", 0, "123456", 1, "MagnusCarlsen", false },
                    { 2, new DateTime(1987, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2787, "hikaru@chess.com", 0, "123456", 1, "HikaruNakamura", false },
                    { 3, new DateTime(1992, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2780, "ding@chess.com", 0, "123456", 1, "DingLiren", false },
                    { 4, new DateTime(1990, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2770, "nepo@chess.com", 0, "123456", 1, "IanNepomniachtchi", false },
                    { 5, new DateTime(1992, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2760, "fabiano@chess.com", 0, "123456", 1, "FabianoCaruana", false },
                    { 6, new DateTime(2003, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2750, "firouzja@chess.com", 0, "123456", 1, "AlirezaFirouzja", false },
                    { 7, new DateTime(1976, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2735, "judit@chess.com", 1, "123456", 1, "JuditPolgar", false },
                    { 8, new DateTime(1994, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2658, "hou@chess.com", 1, "123456", 1, "HouYifan", false },
                    { 9, new DateTime(1943, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2785, "fischer@chess.com", 0, "123456", 1, "BobbyFischer", false },
                    { 10, new DateTime(1963, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2812, "kasparov@chess.com", 0, "123456", 1, "GarryKasparov", false },
                    { 11, new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2100, "cm42@chess.com", 2, "123456", 1, "ChessMaster42", false },
                    { 12, new DateTime(1988, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1800, "knight@chess.com", 0, "123456", 1, "KnightRider", false },
                    { 13, new DateTime(1999, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1950, "queen@chess.com", 1, "123456", 1, "QueenSlayer", false },
                    { 14, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200, "pawn@chess.com", 0, "123456", 1, "PawnStar", false },
                    { 15, new DateTime(1993, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600, "rook@chess.com", 2, "123456", 1, "RookAndRoll", false },
                    { 16, new DateTime(1985, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000, "strategist@chess.com", 0, "123456", 1, "TheStrategist", false },
                    { 17, new DateTime(1997, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1750, "blitz@chess.com", 1, "123456", 1, "BlitzQueen", false },
                    { 18, new DateTime(1980, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200, "checkmate@chess.com", 0, "123456", 1, "CheckmateKing", false },
                    { 19, new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2300, "endgame@chess.com", 0, "123456", 1, "EndgameWizard", false },
                    { 20, new DateTime(1998, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1900, "opening@chess.com", 2, "123456", 1, "OpeningGenius", false },
                    { 21, new DateTime(1990, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, "nico@chess.com", 0, "123456", 0, "Nico", false },
                    { 22, new DateTime(1991, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1620, "alex.martin22@gmail.com", 0, "pwd4821", 1, "AlexMartin", false },
                    { 23, new DateTime(1986, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1475, "sam.garcia7@yahoo.com", 2, "pwd3012", 1, "SamGarcia", false },
                    { 24, new DateTime(1999, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1540, "taylor.lopez13@outlook.com", 1, "pwd6543", 1, "TaylorLopez", false },
                    { 25, new DateTime(1979, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1825, "jordan.johnson41@example.com", 0, "pwd7730", 1, "JordanJohnson", false },
                    { 26, new DateTime(2002, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1360, "morgan.smith5@mail.com", 1, "pwd1904", 1, "MorganSmith", false },
                    { 27, new DateTime(1983, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1588, "casey.brown99@protonmail.com", 2, "pwd5882", 1, "CaseyBrown", false },
                    { 28, new DateTime(1994, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1710, "drew.williams8@hotmail.com", 0, "pwd4127", 1, "DrewWilliams", false },
                    { 29, new DateTime(1996, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1395, "evelyn.jones2@gamesmail.com", 1, "pwd2256", 1, "EvelynJones", false },
                    { 30, new DateTime(1990, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1987, "liam.miller17@playzone.net", 0, "pwd8341", 1, "LiamMiller", false },
                    { 31, new DateTime(2001, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1280, "noah.davis4@chessworld.org", 0, "pwd0192", 1, "NoahDavis", false },
                    { 32, new DateTime(1987, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2035, "oliver.wilson61@boardgames.io", 0, "pwd7723", 1, "OliverWilson", false },
                    { 33, new DateTime(1998, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1762, "elijah.anderson12@strategy.gg", 0, "pwd9406", 1, "ElijahAnderson", false },
                    { 34, new DateTime(1975, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2100, "james.thomas3@gmail.com", 0, "pwd2675", 1, "JamesThomas", false },
                    { 35, new DateTime(1993, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1427, "benjamin.taylor88@yahoo.com", 0, "pwd3819", 1, "BenjaminTaylor", false },
                    { 36, new DateTime(1989, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1674, "lucas.moore47@outlook.com", 0, "pwd6654", 1, "LucasMoore", false },
                    { 37, new DateTime(1997, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1511, "mason.jackson20@example.com", 0, "pwd5580", 1, "MasonJackson", false },
                    { 38, new DateTime(1995, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1799, "logan.white66@mail.com", 2, "pwd1033", 1, "LoganWhite", false },
                    { 39, new DateTime(1984, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1865, "ethan.harris13@protonmail.com", 0, "pwd4545", 1, "EthanHarris", false },
                    { 40, new DateTime(2000, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1322, "ava.thompson31@hotmail.com", 1, "pwd2880", 1, "AvaThompson", false },
                    { 41, new DateTime(1992, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1703, "sophia.martinez55@gamesmail.com", 1, "pwd7201", 1, "SophiaMartinez", false },
                    { 42, new DateTime(1994, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1609, "isabella.robinson9@playzone.net", 1, "pwd4419", 1, "IsabellaRobinson", false },
                    { 43, new DateTime(2003, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1199, "mia.clark77@chessworld.org", 1, "pwd5310", 1, "MiaClark", false },
                    { 44, new DateTime(1982, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1890, "amelia.rodriguez2@boardgames.io", 1, "pwd6752", 1, "AmeliaRodriguez", false },
                    { 45, new DateTime(1990, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1555, "harper.lewis14@strategy.gg", 2, "pwd9944", 1, "HarperLewis", false },
                    { 46, new DateTime(1988, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2001, "charlotte.lee5@gmail.com", 1, "pwd2168", 1, "CharlotteLee", false },
                    { 47, new DateTime(1996, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1448, "zoey.walker42@yahoo.com", 1, "pwd3478", 1, "ZoeyWalker", false },
                    { 48, new DateTime(1981, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2160, "grace.hall23@outlook.com", 1, "pwd8110", 1, "GraceHall", false },
                    { 49, new DateTime(2004, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1015, "luna.allen90@example.com", 1, "pwd9722", 1, "LunaAllen", false },
                    { 50, new DateTime(1999, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1491, "camila.young58@mail.com", 1, "pwd1567", 1, "CamilaYoung", false },
                    { 51, new DateTime(1997, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1734, "aria.king6@protonmail.com", 1, "pwd6633", 1, "AriaKing", false },
                    { 52, new DateTime(1993, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1452, "ella.wright1@hotmail.com", 1, "pwd4870", 1, "EllaWright", false },
                    { 53, new DateTime(1985, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1996, "scarlett.scott33@gamesmail.com", 1, "pwd3355", 1, "ScarlettScott", false },
                    { 54, new DateTime(1991, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1768, "victoria.torres71@playzone.net", 1, "pwd9087", 1, "VictoriaTorres", false },
                    { 55, new DateTime(2000, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1376, "riley.nguyen44@chessworld.org", 2, "pwd2299", 1, "RileyNguyen", false },
                    { 56, new DateTime(1980, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2112, "nora.hill18@boardgames.io", 1, "pwd5501", 1, "NoraHill", false },
                    { 57, new DateTime(1992, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1681, "hazel.flores8@strategy.gg", 1, "pwd7812", 1, "HazelFlores", false },
                    { 58, new DateTime(1998, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1523, "chloe.green69@gmail.com", 1, "pwd0049", 1, "ChloeGreen", false },
                    { 59, new DateTime(1996, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1407, "lily.adams27@yahoo.com", 1, "pwd2783", 1, "LilyAdams", false },
                    { 60, new DateTime(1987, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1837, "penelope.nelson3@outlook.com", 1, "pwd6195", 1, "PenelopeNelson", false },
                    { 61, new DateTime(2005, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 925, "layla.baker52@example.com", 1, "pwd8320", 1, "LaylaBaker", false },
                    { 62, new DateTime(1994, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1570, "zoe.hernandez29@mail.com", 1, "pwd1436", 1, "ZoeHernandez", false },
                    { 63, new DateTime(1990, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1908, "layla.rivera64@protonmail.com", 2, "pwd9902", 1, "LaylaRivera", false },
                    { 64, new DateTime(1989, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1775, "camila.campbell11@hotmail.com", 1, "pwd4646", 1, "CamilaCampbell", false },
                    { 65, new DateTime(1995, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1328, "ella.mitchell39@gamesmail.com", 1, "pwd2057", 1, "EllaMitchell", false },
                    { 66, new DateTime(1992, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1897, "liam.carter72@playzone.net", 0, "pwd7129", 1, "LiamCarter", false },
                    { 67, new DateTime(1986, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2050, "noah.roberts45@chessworld.org", 0, "pwd3771", 1, "NoahRoberts", false },
                    { 68, new DateTime(2001, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1215, "oliver.perez9@boardgames.io", 0, "pwd5566", 1, "OliverPerez", false },
                    { 69, new DateTime(1999, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1504, "elijah.collins23@strategy.gg", 0, "pwd8460", 1, "ElijahCollins", false },
                    { 70, new DateTime(1984, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2228, "james.stewart2@gmail.com", 0, "pwd3918", 1, "JamesStewart", false },
                    { 71, new DateTime(1991, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1637, "benjamin.morris14@yahoo.com", 0, "pwd2734", 1, "BenjaminMorris", false },
                    { 72, new DateTime(1988, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1748, "lucas.rogers57@outlook.com", 0, "pwd6032", 1, "LucasRogers", false },
                    { 73, new DateTime(1996, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1416, "mason.reed81@example.com", 0, "pwd4859", 1, "MasonReed", false },
                    { 74, new DateTime(1990, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1979, "logan.cook33@mail.com", 0, "pwd9220", 1, "LoganCook", false },
                    { 75, new DateTime(1982, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2093, "ethan.bell28@protonmail.com", 0, "pwd1582", 1, "EthanBell", false },
                    { 76, new DateTime(1997, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1345, "ava.murphy46@hotmail.com", 1, "pwd3376", 1, "AvaMurphy", false },
                    { 77, new DateTime(1993, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1707, "sophia.bailey60@gamesmail.com", 1, "pwd7641", 1, "SophiaBailey", false },
                    { 78, new DateTime(1990, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1881, "isabella.rivera38@playzone.net", 1, "pwd0584", 1, "IsabellaRivera", false },
                    { 79, new DateTime(2002, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1247, "mia.cooper5@chessworld.org", 1, "pwd4810", 1, "MiaCooper", false },
                    { 80, new DateTime(1985, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2017, "amelia.peterson70@boardgames.io", 1, "pwd9123", 1, "AmeliaPeterson", false },
                    { 81, new DateTime(1998, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1399, "harper.gray26@strategy.gg", 2, "pwd6408", 1, "HarperGray", false },
                    { 82, new DateTime(1994, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1669, "charlotte.james2@gmail.com", 1, "pwd2841", 1, "CharlotteJames", false },
                    { 83, new DateTime(2000, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1256, "zoey.watson49@yahoo.com", 1, "pwd5027", 1, "ZoeyWatson", false },
                    { 84, new DateTime(1986, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1872, "grace.brooks31@outlook.com", 1, "pwd7789", 1, "GraceBrooks", false },
                    { 85, new DateTime(2004, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 968, "luna.kelly8@example.com", 1, "pwd3902", 1, "LunaKelly", false },
                    { 86, new DateTime(1991, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1530, "camila.sanders12@mail.com", 1, "pwd1478", 1, "CamilaSanders", false },
                    { 87, new DateTime(1997, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1694, "aria.price56@protonmail.com", 1, "pwd5514", 1, "AriaPrice", false },
                    { 88, new DateTime(1995, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1482, "ella.bennett95@hotmail.com", 1, "pwd8686", 1, "EllaBennett", false },
                    { 89, new DateTime(1983, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2039, "scarlett.gray21@gamesmail.com", 1, "pwd3244", 1, "ScarlettGray", false },
                    { 90, new DateTime(1992, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1759, "victoria.russell7@playzone.net", 1, "pwd7011", 1, "VictoriaRussell", false },
                    { 91, new DateTime(1999, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1369, "riley.ortiz40@chessworld.org", 2, "pwd4398", 1, "RileyOrtiz", false },
                    { 92, new DateTime(1981, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2144, "nora.gutierrez6@boardgames.io", 1, "pwd9555", 1, "NoraGutierrez", false },
                    { 93, new DateTime(1993, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1716, "hazel.ramirez63@strategy.gg", 1, "pwd2689", 1, "HazelRamirez", false },
                    { 94, new DateTime(1996, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1526, "chloe.watkins19@gmail.com", 1, "pwd3840", 1, "ChloeWatkins", false },
                    { 95, new DateTime(1998, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1410, "lily.webb85@yahoo.com", 1, "pwd4751", 1, "LilyWebb", false },
                    { 96, new DateTime(1989, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1850, "penelope.santos34@outlook.com", 1, "pwd8920", 1, "PenelopeSantos", false },
                    { 97, new DateTime(2005, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 908, "layla.perry24@example.com", 1, "pwd6147", 1, "LaylaPerry", false },
                    { 98, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1569, "zoe.powell2@mail.com", 1, "pwd7563", 1, "ZoePowell", false },
                    { 99, new DateTime(1990, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1914, "alex.long67@protonmail.com", 0, "pwd0825", 1, "AlexLong", false },
                    { 100, new DateTime(1987, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1602, "casey.patterson44@hotmail.com", 2, "pwd4991", 1, "CaseyPatterson", false },
                    { 101, new DateTime(1992, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1771, "drew.reynolds38@gamesmail.com", 0, "pwd1338", 1, "DrewReynolds", false },
                    { 102, new DateTime(1996, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1497, "noah.fisher10@playzone.net", 0, "pwd2886", 1, "NoahFisher", false },
                    { 103, new DateTime(1991, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1686, "isabella.baker55@chessworld.org", 1, "pwd5511", 1, "IsabellaBaker", false },
                    { 104, new DateTime(1985, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2045, "lucas.hunt9@boardgames.io", 0, "pwd7210", 1, "LucasHunt", false },
                    { 105, new DateTime(1997, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1578, "penelope.henderson30@strategy.gg", 1, "pwd3442", 1, "PenelopeHenderson", false },
                    { 106, new DateTime(1990, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1817, "ethan.baker21@gmail.com", 0, "pwd2065", 1, "EthanBaker", false },
                    { 107, new DateTime(1983, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1967, "ethan.robinson18@yahoo.com", 0, "pwd4379", 1, "EthanRobinson", false },
                    { 108, new DateTime(1999, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1234, "layla.campbell73@outlook.com", 1, "pwd9004", 1, "LaylaCampbell", false },
                    { 109, new DateTime(1986, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1975, "amelia.white50@example.com", 1, "pwd0829", 1, "AmeliaWhite", false },
                    { 110, new DateTime(1994, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1805, "mason.perez61@mail.com", 0, "pwd6577", 1, "MasonPerez", false },
                    { 111, new DateTime(1992, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2159, "camila.garcia26@protonmail.com", 1, "pwd3126", 1, "CamilaGarcia", false },
                    { 112, new DateTime(1995, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1477, "lily.lewis47@hotmail.com", 1, "pwd4950", 1, "LilyLewis", false },
                    { 113, new DateTime(1998, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1194, "amelia.carter8@gamesmail.com", 1, "pwd6274", 1, "AmeliaCarter", false },
                    { 114, new DateTime(1990, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1366, "isabella.jones36@playzone.net", 1, "pwd9531", 1, "IsabellaJones", false },
                    { 115, new DateTime(1993, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1539, "lily.nguyen99@chessworld.org", 2, "pwd2107", 1, "LilyNguyen", false },
                    { 116, new DateTime(1988, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1933, "elijah.martinez4@boardgames.io", 0, "pwd7883", 1, "ElijahMartinez", false },
                    { 117, new DateTime(1996, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1761, "ava.carter59@strategy.gg", 1, "pwd4632", 1, "AvaCarter", false },
                    { 118, new DateTime(1991, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1620, "ella.young34@gmail.com", 1, "pwd8190", 1, "EllaYoung", false },
                    { 119, new DateTime(1984, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1422, "scarlett.smith16@yahoo.com", 1, "pwd2746", 1, "ScarlettSmith", false },
                    { 120, new DateTime(1997, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1262, "casey.jackson37@outlook.com", 2, "pwd7065", 1, "CaseyJackson", false },
                    { 121, new DateTime(1990, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1994, "owen.brooks12@example.com", 0, "pwd3907", 1, "OwenBrooks", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Encounters_TournamentId",
                table: "Encounters",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentUser_RegistrationsId1",
                table: "TournamentUser",
                column: "RegistrationsId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encounters");

            migrationBuilder.DropTable(
                name: "TournamentUser");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
