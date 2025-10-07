using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Checkmate.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
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
                    Pseudo = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                table: "Users",
                columns: new[] { "Id", "Birthdate", "Elo", "Email", "Genre", "Password", "Pseudo", "Role", "isDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2859, "magnus@chess.com", 0, "123456", "MagnusCarlsen", 1, false },
                    { 2, new DateTime(1987, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2787, "hikaru@chess.com", 0, "123456", "HikaruNakamura", 1, false },
                    { 3, new DateTime(1992, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2780, "ding@chess.com", 0, "123456", "DingLiren", 1, false },
                    { 4, new DateTime(1990, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2770, "nepo@chess.com", 0, "123456", "IanNepomniachtchi", 1, false },
                    { 5, new DateTime(1992, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2760, "fabiano@chess.com", 0, "123456", "FabianoCaruana", 1, false },
                    { 6, new DateTime(2003, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2750, "firouzja@chess.com", 0, "123456", "AlirezaFirouzja", 1, false },
                    { 7, new DateTime(1976, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2735, "judit@chess.com", 1, "123456", "JuditPolgar", 1, false },
                    { 8, new DateTime(1994, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2658, "hou@chess.com", 1, "123456", "HouYifan", 1, false },
                    { 9, new DateTime(1943, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2785, "fischer@chess.com", 0, "123456", "BobbyFischer", 1, false },
                    { 10, new DateTime(1963, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2812, "kasparov@chess.com", 0, "123456", "GarryKasparov", 1, false },
                    { 11, new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2100, "cm42@chess.com", 2, "123456", "ChessMaster42", 1, false },
                    { 12, new DateTime(1988, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1800, "knight@chess.com", 0, "123456", "KnightRider", 1, false },
                    { 13, new DateTime(1999, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1950, "queen@chess.com", 1, "123456", "QueenSlayer", 1, false },
                    { 14, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200, "pawn@chess.com", 0, "123456", "PawnStar", 1, false },
                    { 15, new DateTime(1993, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600, "rook@chess.com", 2, "123456", "RookAndRoll", 1, false },
                    { 16, new DateTime(1985, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000, "strategist@chess.com", 0, "123456", "TheStrategist", 1, false },
                    { 17, new DateTime(1997, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1750, "blitz@chess.com", 1, "123456", "BlitzQueen", 1, false },
                    { 18, new DateTime(1980, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200, "checkmate@chess.com", 0, "123456", "CheckmateKing", 1, false },
                    { 19, new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2300, "endgame@chess.com", 0, "123456", "EndgameWizard", 1, false },
                    { 20, new DateTime(1998, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1900, "opening@chess.com", 2, "123456", "OpeningGenius", 1, false },
                    { 21, new DateTime(1990, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2859, "nico@chess.com", 0, "123456", "Nico", 0, false }
                });

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
                name: "IX_Users_Pseudo",
                table: "Users",
                column: "Pseudo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentUser");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
