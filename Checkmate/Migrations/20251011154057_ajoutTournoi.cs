using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Checkmate.Migrations
{
    /// <inheritdoc />
    public partial class ajoutTournoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Category", "CloseDate", "CreationDate", "CurrentRound", "LastUpdateDate", "MaxElo", "MaxPlayer", "MinElo", "MinPlayer", "Name", "NbPlayer", "Place", "Status", "WomenOnly" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2800, 32, 1600, 8, "Open International de Paris", 20, "Paris", 0, false },
                    { 2, 2, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2400, 16, 1200, 4, "Championnat Féminin de Lyon", 10, "Lyon", 0, true },
                    { 3, 2, new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200, 20, 1000, 6, "Blitz d’Hiver de Lille", 14, "Lille", 0, false },
                    { 4, 1, new DateTime(2025, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600, 12, 800, 4, "Tournoi Jeunes Espoirs", 8, "Marseille", 0, false },
                    { 5, 6, new DateTime(2025, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2600, 24, 1500, 8, "Grand Prix de Bordeaux", 18, "Bordeaux", 0, false },
                    { 6, 2, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2400, 20, 1300, 6, "Open Mixte de Toulouse", 16, "Toulouse", 0, false },
                    { 7, 1, new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1400, 16, 0, 4, "Tournoi des Rookies", 9, "Nantes", 0, false },
                    { 8, 2, new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2600, 32, 1400, 10, "Championnat de Bretagne", 22, "Rennes", 0, false },
                    { 9, 3, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200, 20, 1100, 4, "Open Féminin de Nice", 12, "Nice", 0, true },
                    { 10, 2, new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2600, 28, 1500, 12, "Tournoi Rapide du Capitole", 24, "Toulouse", 0, false },
                    { 11, 6, new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2800, 32, 1600, 12, "Festival Échecs de Cannes", 32, "Cannes", 0, false },
                    { 12, 1, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2100, 24, 1000, 6, "Open Universitaire de Grenoble", 14, "Grenoble", 0, false },
                    { 13, 2, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, 16, 1000, 8, "Coupe des Dames", 8, "Strasbourg", 0, true },
                    { 14, 4, new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, 20, 1300, 8, "Tournoi de la Montagne Noire", 15, "Carcassonne", 0, false },
                    { 15, 1, new DateTime(2025, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500, 16, 800, 6, "Championnat Régional Jeunes", 10, "Dijon", 0, false },
                    { 16, 4, new DateTime(2025, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2800, 20, 1500, 8, "Tournoi des Légendes", 20, "Reims", 0, false },
                    { 17, 3, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, 32, 1300, 10, "Open de Printemps", 25, "Angers", 0, false },
                    { 18, 2, new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200, 16, 1100, 4, "Blitz Féminin de Montpellier", 10, "Montpellier", 0, true },
                    { 19, 6, new DateTime(2025, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2700, 28, 1500, 12, "Open National d’Été", 20, "La Rochelle", 0, false },
                    { 20, 1, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600, 20, 800, 6, "Open Juniors du Nord", 14, "Lille", 0, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
