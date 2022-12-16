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
                    { "admin", 0, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "17f5eb16-1caf-43f1-a06d-1d1666644b0d", "admin@domain.com", false, "AdminFirstName", 1, "AdminLastName", false, null, "eg", "ADMIN@DOMAIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEGwcwxceAN3E4OrcRi/JPu4ybVhInPVsoEQL2e+dOcpg19o16xluI/h8Mn4zkR+sXA==", null, false, "280a33ad-e6f8-4430-9775-33afdf548448", false, "admin" },
                    { "initial-manager", 0, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "e305d487-1418-4aa3-bee0-7dde7d488cf4", "initialmanager@domain.com", false, "ManagerFirstName", 1, "ManagerLastName", false, null, "eg", "INITIALMANAGER@DOMAIN.COM", "INITIALMANAGER", "AQAAAAIAAYagAAAAEFV0WGXKCtEhsqt3NPL9OYVgh4DHCg+0w/R+zQxPL/KdjF1Khrgw6C9Icmd3U8tHzg==", null, false, "4fe43a16-ecdd-4e65-9431-7504f5302e60", false, "initialManager" }
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
