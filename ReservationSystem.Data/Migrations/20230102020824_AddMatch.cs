using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b7a833f-b0f1-4a80-8843-209916495e53", "AQAAAAIAAYagAAAAEMssPSPFZ7eF2QgQRmOSq02sCCEKSx/NIkf1hbB4vzeTsfneSnthMQ4FUlxJxEolHQ==", "ac1950f6-bcb8-49fd-b2e4-e489300d9ca5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ecb0b37-107a-458b-95c8-eccae12327b5", "AQAAAAIAAYagAAAAEG4qQcoKX/4NYecsmxpoyg+BbkAxm0epaaBiMXOYSol/EQnlSHK5NkuNPn0G6kmPLA==", "0db995cd-8f31-4c86-9d42-c1de2923e46c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5677558c-5eb9-40fc-b722-cf39bdceb4f4", "AQAAAAIAAYagAAAAEC8D1HOG1LJpXhlwGPt7WSho0OeIgqegxANItnExhFH2bYDPTH57NZ464EevIs2+WA==", "cc9ca8f2-3cff-4fa9-99e8-fca1467b05f5" });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayTeamName", "DateTime", "FirstLinesman", "HomeTeamName", "Referee", "SecondLinesman", "StadiumName" },
                values: new object[] { -1, "Spain", new DateTime(2023, 2, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), "First Linesman 1", "France", "Referee 1", "Second Linesman 1", "Ahmad bin Ali Stadium" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Column", "MatchId", "Row", "ReservationId" },
                values: new object[,]
                {
                    { 0, -1, 0, null },
                    { 1, -1, 0, null },
                    { 2, -1, 0, null },
                    { 3, -1, 0, null },
                    { 4, -1, 0, null },
                    { 5, -1, 0, null },
                    { 6, -1, 0, null },
                    { 7, -1, 0, null },
                    { 8, -1, 0, null },
                    { 9, -1, 0, null },
                    { 10, -1, 0, null },
                    { 11, -1, 0, null },
                    { 12, -1, 0, null },
                    { 13, -1, 0, null },
                    { 14, -1, 0, null },
                    { 15, -1, 0, null },
                    { 0, -1, 1, null },
                    { 1, -1, 1, null },
                    { 2, -1, 1, null },
                    { 3, -1, 1, null },
                    { 4, -1, 1, null },
                    { 5, -1, 1, null },
                    { 6, -1, 1, null },
                    { 7, -1, 1, null },
                    { 8, -1, 1, null },
                    { 9, -1, 1, null },
                    { 10, -1, 1, null },
                    { 11, -1, 1, null },
                    { 12, -1, 1, null },
                    { 13, -1, 1, null },
                    { 14, -1, 1, null },
                    { 15, -1, 1, null },
                    { 0, -1, 2, null },
                    { 1, -1, 2, null },
                    { 2, -1, 2, null },
                    { 3, -1, 2, null },
                    { 4, -1, 2, null },
                    { 5, -1, 2, null },
                    { 6, -1, 2, null },
                    { 7, -1, 2, null },
                    { 8, -1, 2, null },
                    { 9, -1, 2, null },
                    { 10, -1, 2, null },
                    { 11, -1, 2, null },
                    { 12, -1, 2, null },
                    { 13, -1, 2, null },
                    { 14, -1, 2, null },
                    { 15, -1, 2, null },
                    { 0, -1, 3, null },
                    { 1, -1, 3, null },
                    { 2, -1, 3, null },
                    { 3, -1, 3, null },
                    { 4, -1, 3, null },
                    { 5, -1, 3, null },
                    { 6, -1, 3, null },
                    { 7, -1, 3, null },
                    { 8, -1, 3, null },
                    { 9, -1, 3, null },
                    { 10, -1, 3, null },
                    { 11, -1, 3, null },
                    { 12, -1, 3, null },
                    { 13, -1, 3, null },
                    { 14, -1, 3, null },
                    { 15, -1, 3, null },
                    { 0, -1, 4, null },
                    { 1, -1, 4, null },
                    { 2, -1, 4, null },
                    { 3, -1, 4, null },
                    { 4, -1, 4, null },
                    { 5, -1, 4, null },
                    { 6, -1, 4, null },
                    { 7, -1, 4, null },
                    { 8, -1, 4, null },
                    { 9, -1, 4, null },
                    { 10, -1, 4, null },
                    { 11, -1, 4, null },
                    { 12, -1, 4, null },
                    { 13, -1, 4, null },
                    { 14, -1, 4, null },
                    { 15, -1, 4, null },
                    { 0, -1, 5, null },
                    { 1, -1, 5, null },
                    { 2, -1, 5, null },
                    { 3, -1, 5, null },
                    { 4, -1, 5, null },
                    { 5, -1, 5, null },
                    { 6, -1, 5, null },
                    { 7, -1, 5, null },
                    { 8, -1, 5, null },
                    { 9, -1, 5, null },
                    { 10, -1, 5, null },
                    { 11, -1, 5, null },
                    { 12, -1, 5, null },
                    { 13, -1, 5, null },
                    { 14, -1, 5, null },
                    { 15, -1, 5, null },
                    { 0, -1, 6, null },
                    { 1, -1, 6, null },
                    { 2, -1, 6, null },
                    { 3, -1, 6, null },
                    { 4, -1, 6, null },
                    { 5, -1, 6, null },
                    { 6, -1, 6, null },
                    { 7, -1, 6, null },
                    { 8, -1, 6, null },
                    { 9, -1, 6, null },
                    { 10, -1, 6, null },
                    { 11, -1, 6, null },
                    { 12, -1, 6, null },
                    { 13, -1, 6, null },
                    { 14, -1, 6, null },
                    { 15, -1, 6, null },
                    { 0, -1, 7, null },
                    { 1, -1, 7, null },
                    { 2, -1, 7, null },
                    { 3, -1, 7, null },
                    { 4, -1, 7, null },
                    { 5, -1, 7, null },
                    { 6, -1, 7, null },
                    { 7, -1, 7, null },
                    { 8, -1, 7, null },
                    { 9, -1, 7, null },
                    { 10, -1, 7, null },
                    { 11, -1, 7, null },
                    { 12, -1, 7, null },
                    { 13, -1, 7, null },
                    { 14, -1, 7, null },
                    { 15, -1, 7, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, -1, 0 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, -1, 1 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, -1, 2 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, -1, 3 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, -1, 4 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, -1, 5 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, -1, 6 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 0, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 1, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 2, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 3, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 4, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 5, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 6, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 7, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 8, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 9, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 10, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 11, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 12, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 13, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 14, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "Column", "MatchId", "Row" },
                keyValues: new object[] { 15, -1, 7 });

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b72c720e-1c7a-485d-9a26-69305329d902", "AQAAAAIAAYagAAAAEMzVke7NSdo+jza3wZIhkKo4Xr8hH50VZyG3k2OCndfHpFFLTwyLF4B39RREmvhl2A==", "93d4177c-06c7-488c-9cb1-52828e0469bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afa32d1c-0470-4850-aa60-c25aa06dbe9e", "AQAAAAIAAYagAAAAELGU32ycHW3zMu20ufwfFVEonpmzCYSlFM1gU7/EmYQQu7yqIE+tWKehS7xBwR34hA==", "8fefbde6-5ed3-4dbf-97df-5156973ffe56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce46d7f4-3d6c-411d-8268-f2fbe1abbe43", "AQAAAAIAAYagAAAAEPXPK/LWhFK9s8jNVEE2AJbF3UHTYeueBf94+wXGm+mDtw1Gsrw/e+adU2weQfgZsQ==", "c76bc6c1-fb9c-4195-bc02-b6b4428f86fb" });
        }
    }
}
