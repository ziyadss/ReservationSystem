using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Al Janoub Stadium");

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Stadium 974");

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 1, 7 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c30a038e-3aa0-4bd4-88f2-d63b97f790e8", "AQAAAAIAAYagAAAAEIPUfFGtwwmDR4PR4pxIR4tJvluQWtYRE538HIyX03bodtvHx+YtT/EEkdtT8BtYfg==", "2723d477-bab1-4531-8a47-3d3b4ccb3528" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e6d2b7b-c9a4-4918-90fa-bdf7cfe86239", "AQAAAAIAAYagAAAAEInaGlQn6oeKqVkRK4+M9Rg2j2/kt737hTgVYJ2aXRIPxvNiFuID6RD/+5fhyhDL1w==", "b6fbc76b-3f1a-4a25-90e1-bc5b7176d20a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35b3569b-3250-49ab-9f6f-9da33f9075ff", "AQAAAAIAAYagAAAAEMj80pXoUkc+9EMDeO7H0B+R3zjQKty8kPUwAng2+fRS8XtsC8axxIFQZSUFOJX0Zg==", "3a5c13cd-a01d-4584-9d5f-ab2ada1c45a2" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTime", "HomeTeamName", "StadiumName" },
                values: new object[] { new DateTime(2023, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Belgium", "Lusail Stadium" });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayTeamName", "DateTime", "FirstLinesman", "HomeTeamName", "Referee", "SecondLinesman", "StadiumName" },
                values: new object[,]
                {
                    { 2, "Germany", new DateTime(2023, 2, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), "First Linesman 2", "Spain", "Referee 2", "Second Linesman 2", "Ahmad bin Ali Stadium" },
                    { 3, "Belgium", new DateTime(2023, 3, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), "First Linesman 3", "Portugal", "Referee 3", "Second Linesman 1", "Lusail Stadium" },
                    { 4, "Portugal", new DateTime(2023, 4, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), "First Linesman 1", "Netherlands", "Referee 4", "Second Linesman 2", "Ahmad bin Ali Stadium" },
                    { 5, "Croatia", new DateTime(2023, 5, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "First Linesman 2", "Germany", "Referee 1", "Second Linesman 1", "Lusail Stadium" },
                    { 6, "Portugal", new DateTime(2023, 6, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), "First Linesman 3", "France", "Referee 2", "Second Linesman 2", "Ahmad bin Ali Stadium" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Column", "MatchId", "Row", "ReservationId" },
                values: new object[,]
                {
                    { 0, 2, 0, null },
                    { 1, 2, 0, null },
                    { 2, 2, 0, null },
                    { 3, 2, 0, null },
                    { 4, 2, 0, null },
                    { 5, 2, 0, null },
                    { 6, 2, 0, null },
                    { 7, 2, 0, null },
                    { 8, 2, 0, null },
                    { 9, 2, 0, null },
                    { 10, 2, 0, null },
                    { 11, 2, 0, null },
                    { 12, 2, 0, null },
                    { 13, 2, 0, null },
                    { 14, 2, 0, null },
                    { 15, 2, 0, null },
                    { 0, 2, 1, null },
                    { 1, 2, 1, null },
                    { 2, 2, 1, null },
                    { 3, 2, 1, null },
                    { 4, 2, 1, null },
                    { 5, 2, 1, null },
                    { 6, 2, 1, null },
                    { 7, 2, 1, null },
                    { 8, 2, 1, null },
                    { 9, 2, 1, null },
                    { 10, 2, 1, null },
                    { 11, 2, 1, null },
                    { 12, 2, 1, null },
                    { 13, 2, 1, null },
                    { 14, 2, 1, null },
                    { 15, 2, 1, null },
                    { 0, 2, 2, null },
                    { 1, 2, 2, null },
                    { 2, 2, 2, null },
                    { 3, 2, 2, null },
                    { 4, 2, 2, null },
                    { 5, 2, 2, null },
                    { 6, 2, 2, null },
                    { 7, 2, 2, null },
                    { 8, 2, 2, null },
                    { 9, 2, 2, null },
                    { 10, 2, 2, null },
                    { 11, 2, 2, null },
                    { 12, 2, 2, null },
                    { 13, 2, 2, null },
                    { 14, 2, 2, null },
                    { 15, 2, 2, null },
                    { 0, 2, 3, null },
                    { 1, 2, 3, null },
                    { 2, 2, 3, null },
                    { 3, 2, 3, null },
                    { 4, 2, 3, null },
                    { 5, 2, 3, null },
                    { 6, 2, 3, null },
                    { 7, 2, 3, null },
                    { 8, 2, 3, null },
                    { 9, 2, 3, null },
                    { 10, 2, 3, null },
                    { 11, 2, 3, null },
                    { 12, 2, 3, null },
                    { 13, 2, 3, null },
                    { 14, 2, 3, null },
                    { 15, 2, 3, null },
                    { 0, 2, 4, null },
                    { 1, 2, 4, null },
                    { 2, 2, 4, null },
                    { 3, 2, 4, null },
                    { 4, 2, 4, null },
                    { 5, 2, 4, null },
                    { 6, 2, 4, null },
                    { 7, 2, 4, null },
                    { 8, 2, 4, null },
                    { 9, 2, 4, null },
                    { 10, 2, 4, null },
                    { 11, 2, 4, null },
                    { 12, 2, 4, null },
                    { 13, 2, 4, null },
                    { 14, 2, 4, null },
                    { 15, 2, 4, null },
                    { 0, 2, 5, null },
                    { 1, 2, 5, null },
                    { 2, 2, 5, null },
                    { 3, 2, 5, null },
                    { 4, 2, 5, null },
                    { 5, 2, 5, null },
                    { 6, 2, 5, null },
                    { 7, 2, 5, null },
                    { 8, 2, 5, null },
                    { 9, 2, 5, null },
                    { 10, 2, 5, null },
                    { 11, 2, 5, null },
                    { 12, 2, 5, null },
                    { 13, 2, 5, null },
                    { 14, 2, 5, null },
                    { 15, 2, 5, null },
                    { 0, 2, 6, null },
                    { 1, 2, 6, null },
                    { 2, 2, 6, null },
                    { 3, 2, 6, null },
                    { 4, 2, 6, null },
                    { 5, 2, 6, null },
                    { 6, 2, 6, null },
                    { 7, 2, 6, null },
                    { 8, 2, 6, null },
                    { 9, 2, 6, null },
                    { 10, 2, 6, null },
                    { 11, 2, 6, null },
                    { 12, 2, 6, null },
                    { 13, 2, 6, null },
                    { 14, 2, 6, null },
                    { 15, 2, 6, null },
                    { 0, 2, 7, null },
                    { 1, 2, 7, null },
                    { 2, 2, 7, null },
                    { 3, 2, 7, null },
                    { 4, 2, 7, null },
                    { 5, 2, 7, null },
                    { 6, 2, 7, null },
                    { 7, 2, 7, null },
                    { 8, 2, 7, null },
                    { 9, 2, 7, null },
                    { 10, 2, 7, null },
                    { 11, 2, 7, null },
                    { 12, 2, 7, null },
                    { 13, 2, 7, null },
                    { 14, 2, 7, null },
                    { 15, 2, 7, null },
                    { 0, 3, 0, null },
                    { 1, 3, 0, null },
                    { 0, 4, 0, null },
                    { 1, 4, 0, null },
                    { 2, 4, 0, null },
                    { 3, 4, 0, null },
                    { 4, 4, 0, null },
                    { 5, 4, 0, null },
                    { 6, 4, 0, null },
                    { 7, 4, 0, null },
                    { 8, 4, 0, null },
                    { 9, 4, 0, null },
                    { 10, 4, 0, null },
                    { 11, 4, 0, null },
                    { 12, 4, 0, null },
                    { 13, 4, 0, null },
                    { 14, 4, 0, null },
                    { 15, 4, 0, null },
                    { 0, 4, 1, null },
                    { 1, 4, 1, null },
                    { 2, 4, 1, null },
                    { 3, 4, 1, null },
                    { 4, 4, 1, null },
                    { 5, 4, 1, null },
                    { 6, 4, 1, null },
                    { 7, 4, 1, null },
                    { 8, 4, 1, null },
                    { 9, 4, 1, null },
                    { 10, 4, 1, null },
                    { 11, 4, 1, null },
                    { 12, 4, 1, null },
                    { 13, 4, 1, null },
                    { 14, 4, 1, null },
                    { 15, 4, 1, null },
                    { 0, 4, 2, null },
                    { 1, 4, 2, null },
                    { 2, 4, 2, null },
                    { 3, 4, 2, null },
                    { 4, 4, 2, null },
                    { 5, 4, 2, null },
                    { 6, 4, 2, null },
                    { 7, 4, 2, null },
                    { 8, 4, 2, null },
                    { 9, 4, 2, null },
                    { 10, 4, 2, null },
                    { 11, 4, 2, null },
                    { 12, 4, 2, null },
                    { 13, 4, 2, null },
                    { 14, 4, 2, null },
                    { 15, 4, 2, null },
                    { 0, 4, 3, null },
                    { 1, 4, 3, null },
                    { 2, 4, 3, null },
                    { 3, 4, 3, null },
                    { 4, 4, 3, null },
                    { 5, 4, 3, null },
                    { 6, 4, 3, null },
                    { 7, 4, 3, null },
                    { 8, 4, 3, null },
                    { 9, 4, 3, null },
                    { 10, 4, 3, null },
                    { 11, 4, 3, null },
                    { 12, 4, 3, null },
                    { 13, 4, 3, null },
                    { 14, 4, 3, null },
                    { 15, 4, 3, null },
                    { 0, 4, 4, null },
                    { 1, 4, 4, null },
                    { 2, 4, 4, null },
                    { 3, 4, 4, null },
                    { 4, 4, 4, null },
                    { 5, 4, 4, null },
                    { 6, 4, 4, null },
                    { 7, 4, 4, null },
                    { 8, 4, 4, null },
                    { 9, 4, 4, null },
                    { 10, 4, 4, null },
                    { 11, 4, 4, null },
                    { 12, 4, 4, null },
                    { 13, 4, 4, null },
                    { 14, 4, 4, null },
                    { 15, 4, 4, null },
                    { 0, 4, 5, null },
                    { 1, 4, 5, null },
                    { 2, 4, 5, null },
                    { 3, 4, 5, null },
                    { 4, 4, 5, null },
                    { 5, 4, 5, null },
                    { 6, 4, 5, null },
                    { 7, 4, 5, null },
                    { 8, 4, 5, null },
                    { 9, 4, 5, null },
                    { 10, 4, 5, null },
                    { 11, 4, 5, null },
                    { 12, 4, 5, null },
                    { 13, 4, 5, null },
                    { 14, 4, 5, null },
                    { 15, 4, 5, null },
                    { 0, 4, 6, null },
                    { 1, 4, 6, null },
                    { 2, 4, 6, null },
                    { 3, 4, 6, null },
                    { 4, 4, 6, null },
                    { 5, 4, 6, null },
                    { 6, 4, 6, null },
                    { 7, 4, 6, null },
                    { 8, 4, 6, null },
                    { 9, 4, 6, null },
                    { 10, 4, 6, null },
                    { 11, 4, 6, null },
                    { 12, 4, 6, null },
                    { 13, 4, 6, null },
                    { 14, 4, 6, null },
                    { 15, 4, 6, null },
                    { 0, 4, 7, null },
                    { 1, 4, 7, null },
                    { 2, 4, 7, null },
                    { 3, 4, 7, null },
                    { 4, 4, 7, null },
                    { 5, 4, 7, null },
                    { 6, 4, 7, null },
                    { 7, 4, 7, null },
                    { 8, 4, 7, null },
                    { 9, 4, 7, null },
                    { 10, 4, 7, null },
                    { 11, 4, 7, null },
                    { 12, 4, 7, null },
                    { 13, 4, 7, null },
                    { 14, 4, 7, null },
                    { 15, 4, 7, null },
                    { 0, 5, 0, null },
                    { 1, 5, 0, null },
                    { 0, 6, 0, null },
                    { 1, 6, 0, null },
                    { 2, 6, 0, null },
                    { 3, 6, 0, null },
                    { 4, 6, 0, null },
                    { 5, 6, 0, null },
                    { 6, 6, 0, null },
                    { 7, 6, 0, null },
                    { 8, 6, 0, null },
                    { 9, 6, 0, null },
                    { 10, 6, 0, null },
                    { 11, 6, 0, null },
                    { 12, 6, 0, null },
                    { 13, 6, 0, null },
                    { 14, 6, 0, null },
                    { 15, 6, 0, null },
                    { 0, 6, 1, null },
                    { 1, 6, 1, null },
                    { 2, 6, 1, null },
                    { 3, 6, 1, null },
                    { 4, 6, 1, null },
                    { 5, 6, 1, null },
                    { 6, 6, 1, null },
                    { 7, 6, 1, null },
                    { 8, 6, 1, null },
                    { 9, 6, 1, null },
                    { 10, 6, 1, null },
                    { 11, 6, 1, null },
                    { 12, 6, 1, null },
                    { 13, 6, 1, null },
                    { 14, 6, 1, null },
                    { 15, 6, 1, null },
                    { 0, 6, 2, null },
                    { 1, 6, 2, null },
                    { 2, 6, 2, null },
                    { 3, 6, 2, null },
                    { 4, 6, 2, null },
                    { 5, 6, 2, null },
                    { 6, 6, 2, null },
                    { 7, 6, 2, null },
                    { 8, 6, 2, null },
                    { 9, 6, 2, null },
                    { 10, 6, 2, null },
                    { 11, 6, 2, null },
                    { 12, 6, 2, null },
                    { 13, 6, 2, null },
                    { 14, 6, 2, null },
                    { 15, 6, 2, null },
                    { 0, 6, 3, null },
                    { 1, 6, 3, null },
                    { 2, 6, 3, null },
                    { 3, 6, 3, null },
                    { 4, 6, 3, null },
                    { 5, 6, 3, null },
                    { 6, 6, 3, null },
                    { 7, 6, 3, null },
                    { 8, 6, 3, null },
                    { 9, 6, 3, null },
                    { 10, 6, 3, null },
                    { 11, 6, 3, null },
                    { 12, 6, 3, null },
                    { 13, 6, 3, null },
                    { 14, 6, 3, null },
                    { 15, 6, 3, null },
                    { 0, 6, 4, null },
                    { 1, 6, 4, null },
                    { 2, 6, 4, null },
                    { 3, 6, 4, null },
                    { 4, 6, 4, null },
                    { 5, 6, 4, null },
                    { 6, 6, 4, null },
                    { 7, 6, 4, null },
                    { 8, 6, 4, null },
                    { 9, 6, 4, null },
                    { 10, 6, 4, null },
                    { 11, 6, 4, null },
                    { 12, 6, 4, null },
                    { 13, 6, 4, null },
                    { 14, 6, 4, null },
                    { 15, 6, 4, null },
                    { 0, 6, 5, null },
                    { 1, 6, 5, null },
                    { 2, 6, 5, null },
                    { 3, 6, 5, null },
                    { 4, 6, 5, null },
                    { 5, 6, 5, null },
                    { 6, 6, 5, null },
                    { 7, 6, 5, null },
                    { 8, 6, 5, null },
                    { 9, 6, 5, null },
                    { 10, 6, 5, null },
                    { 11, 6, 5, null },
                    { 12, 6, 5, null },
                    { 13, 6, 5, null },
                    { 14, 6, 5, null },
                    { 15, 6, 5, null },
                    { 0, 6, 6, null },
                    { 1, 6, 6, null },
                    { 2, 6, 6, null },
                    { 3, 6, 6, null },
                    { 4, 6, 6, null },
                    { 5, 6, 6, null },
                    { 6, 6, 6, null },
                    { 7, 6, 6, null },
                    { 8, 6, 6, null },
                    { 9, 6, 6, null },
                    { 10, 6, 6, null },
                    { 11, 6, 6, null },
                    { 12, 6, 6, null },
                    { 13, 6, 6, null },
                    { 14, 6, 6, null },
                    { 15, 6, 6, null },
                    { 0, 6, 7, null },
                    { 1, 6, 7, null },
                    { 2, 6, 7, null },
                    { 3, 6, 7, null },
                    { 4, 6, 7, null },
                    { 5, 6, 7, null },
                    { 6, 6, 7, null },
                    { 7, 6, 7, null },
                    { 8, 6, 7, null },
                    { 9, 6, 7, null },
                    { 10, 6, 7, null },
                    { 11, 6, 7, null },
                    { 12, 6, 7, null },
                    { 13, 6, 7, null },
                    { 14, 6, 7, null },
                    { 15, 6, 7, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 2, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 2, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 2, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 2, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 3, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 3, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 4, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 4, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 4, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 4, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 4, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 5, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 5, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 6, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 6, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 6, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 6, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 6, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 6, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 6, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, 6, 7 });

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f6e0e97-fc68-4e91-9f25-226e118ec2eb", "AQAAAAIAAYagAAAAEKDGeDg3RKjxcX9gF1jvA+Vvm7V4T5KL7fekyxFe6ug4WVjdSC+98rw7Mq89AA6MGg==", "f224272e-1740-460b-be89-ab27e8b1bf78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b82e64d2-f2fb-4f58-ab2c-903169302d4b", "AQAAAAIAAYagAAAAECtpkFMezkvMAESaflhnNBq4ovVJmzl50G9wbmMRbmzJdwbKOUsKMz8Plx8ymp4YEQ==", "5052df68-9b15-42c4-8ee3-f2bdb261d17f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e452c260-b742-470d-b884-cc94b6089c7e", "AQAAAAIAAYagAAAAEJovD6HkOP/PUzesA+XpXlEQmy69qK9IgnMCUiMIL5nlaDbCwl1VmdWedHj/fLT/pQ==", "c6367905-73e0-4c4f-a5a6-a1b59f77e1fd" });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTime", "HomeTeamName", "StadiumName" },
                values: new object[] { new DateTime(2023, 2, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), "France", "Ahmad bin Ali Stadium" });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Name", "Columns", "Rows" },
                values: new object[,]
                {
                    { "Al Janoub Stadium", 512, 256 },
                    { "Stadium 974", 256, 128 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Column", "MatchId", "Row", "ReservationId" },
                values: new object[,]
                {
                    { 2, 1, 0, null },
                    { 3, 1, 0, null },
                    { 4, 1, 0, null },
                    { 5, 1, 0, null },
                    { 6, 1, 0, null },
                    { 7, 1, 0, null },
                    { 8, 1, 0, null },
                    { 9, 1, 0, null },
                    { 10, 1, 0, null },
                    { 11, 1, 0, null },
                    { 12, 1, 0, null },
                    { 13, 1, 0, null },
                    { 14, 1, 0, null },
                    { 15, 1, 0, null },
                    { 0, 1, 1, null },
                    { 1, 1, 1, null },
                    { 2, 1, 1, null },
                    { 3, 1, 1, null },
                    { 4, 1, 1, null },
                    { 5, 1, 1, null },
                    { 6, 1, 1, null },
                    { 7, 1, 1, null },
                    { 8, 1, 1, null },
                    { 9, 1, 1, null },
                    { 10, 1, 1, null },
                    { 11, 1, 1, null },
                    { 12, 1, 1, null },
                    { 13, 1, 1, null },
                    { 14, 1, 1, null },
                    { 15, 1, 1, null },
                    { 0, 1, 2, null },
                    { 1, 1, 2, null },
                    { 2, 1, 2, null },
                    { 3, 1, 2, null },
                    { 4, 1, 2, null },
                    { 5, 1, 2, null },
                    { 6, 1, 2, null },
                    { 7, 1, 2, null },
                    { 8, 1, 2, null },
                    { 9, 1, 2, null },
                    { 10, 1, 2, null },
                    { 11, 1, 2, null },
                    { 12, 1, 2, null },
                    { 13, 1, 2, null },
                    { 14, 1, 2, null },
                    { 15, 1, 2, null },
                    { 0, 1, 3, null },
                    { 1, 1, 3, null },
                    { 2, 1, 3, null },
                    { 3, 1, 3, null },
                    { 4, 1, 3, null },
                    { 5, 1, 3, null },
                    { 6, 1, 3, null },
                    { 7, 1, 3, null },
                    { 8, 1, 3, null },
                    { 9, 1, 3, null },
                    { 10, 1, 3, null },
                    { 11, 1, 3, null },
                    { 12, 1, 3, null },
                    { 13, 1, 3, null },
                    { 14, 1, 3, null },
                    { 15, 1, 3, null },
                    { 0, 1, 4, null },
                    { 1, 1, 4, null },
                    { 2, 1, 4, null },
                    { 3, 1, 4, null },
                    { 4, 1, 4, null },
                    { 5, 1, 4, null },
                    { 6, 1, 4, null },
                    { 7, 1, 4, null },
                    { 8, 1, 4, null },
                    { 9, 1, 4, null },
                    { 10, 1, 4, null },
                    { 11, 1, 4, null },
                    { 12, 1, 4, null },
                    { 13, 1, 4, null },
                    { 14, 1, 4, null },
                    { 15, 1, 4, null },
                    { 0, 1, 5, null },
                    { 1, 1, 5, null },
                    { 2, 1, 5, null },
                    { 3, 1, 5, null },
                    { 4, 1, 5, null },
                    { 5, 1, 5, null },
                    { 6, 1, 5, null },
                    { 7, 1, 5, null },
                    { 8, 1, 5, null },
                    { 9, 1, 5, null },
                    { 10, 1, 5, null },
                    { 11, 1, 5, null },
                    { 12, 1, 5, null },
                    { 13, 1, 5, null },
                    { 14, 1, 5, null },
                    { 15, 1, 5, null },
                    { 0, 1, 6, null },
                    { 1, 1, 6, null },
                    { 2, 1, 6, null },
                    { 3, 1, 6, null },
                    { 4, 1, 6, null },
                    { 5, 1, 6, null },
                    { 6, 1, 6, null },
                    { 7, 1, 6, null },
                    { 8, 1, 6, null },
                    { 9, 1, 6, null },
                    { 10, 1, 6, null },
                    { 11, 1, 6, null },
                    { 12, 1, 6, null },
                    { 13, 1, 6, null },
                    { 14, 1, 6, null },
                    { 15, 1, 6, null },
                    { 0, 1, 7, null },
                    { 1, 1, 7, null },
                    { 2, 1, 7, null },
                    { 3, 1, 7, null },
                    { 4, 1, 7, null },
                    { 5, 1, 7, null },
                    { 6, 1, 7, null },
                    { 7, 1, 7, null },
                    { 8, 1, 7, null },
                    { 9, 1, 7, null },
                    { 10, 1, 7, null },
                    { 11, 1, 7, null },
                    { 12, 1, 7, null },
                    { 13, 1, 7, null },
                    { 14, 1, 7, null },
                    { 15, 1, 7, null }
                });
        }
    }
}
