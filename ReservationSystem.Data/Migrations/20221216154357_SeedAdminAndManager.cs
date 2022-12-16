using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminAndManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", null, "Admin", "ADMIN" },
                    { "Manager", null, "Manager", "MANAGER" },
                    { "User", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "Nationality", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin", 0, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "9b3f41e6-bf17-4da0-a2d6-974f425beb83", "admin@domain.com", false, "AdminFirstName", 1, "AdminLastName", false, null, "eg", "ADMIN@DOMAIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEFVWP8hMCi5o0qaRMZ3TlIJqLW9pcNcC0H6ciajubmzlYrfr6WFj1BjbjnMBoz3ssg==", null, false, "fe83c663-be26-4eda-bc54-f8fa6ea4bc02", false, "admin" },
                    { "initial-manager", 0, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "0f2ebca1-eb03-4359-9d1e-67e637324731", "initialmanager@domain.com", false, "ManagerFirstName", 1, "ManagerLastName", false, null, "eg", "INITIALMANAGER@DOMAIN.COM", "INITIALMANAGER", "AQAAAAIAAYagAAAAEA76RXNpi9eIH0/It69SpMbsg7L9cKM2xASJWpOoJsJctWe8Yk2ELESAwCka5Z4cwA==", null, false, "69fdb02b-dfed-4104-804f-bca91b5315bd", false, "initialManager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Admin", "admin" },
                    { "Manager", "initial-manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "User");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Manager", "initial-manager" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Manager");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager");
        }
    }
}
