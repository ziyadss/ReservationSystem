using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd8d299c-5306-4e24-93f1-d5ee4c88da4b", "AQAAAAIAAYagAAAAEKs74etYQGS47szG6Gmb7QM9KTQRWxnGiHepj1+ULXyC04mlM+2d1FrPdLC4sp7Fyg==", "c997c594-13ab-4353-996b-1c0d0d8253c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b69d58e-cb4c-4980-9c4c-6269367f6992", "AQAAAAIAAYagAAAAEJNPaO6Zm1cqIie3JF+9/7lWOTMPql8/Mmjzq1bLtYzn/f8ZBYXnD/WCJpjT9+3xqA==", "5de2f2bf-cd73-47d6-a604-803dbda3318e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "Nationality", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "initial-user", 0, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "8a9a506b-f8ea-4ea5-8e57-d93619821996", "initialmanager@domain.com", false, "UserFirstName", 1, "UserLastName", false, null, "eg", "INITIALMANAGER@DOMAIN.COM", "INITIALUSER", "AQAAAAIAAYagAAAAED76nfq2wylGYsrRjwvrP30RKPbQi4cn+o96/yEBQPOpxiNdL6j4scbJCP7dAZ/urw==", null, false, "8d1a4376-8974-4920-a2f5-b6a7234e476e", false, "initialUser" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "User", "initial-user" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "User", "initial-user" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-user");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21aabd6d-a323-41e1-89b6-6acb1f8c1231", "AQAAAAIAAYagAAAAEEudTJhvQDjVytqGgetV9fqVYgYK0gSVKnKtfIQHeX3gz0c2Rw58sZVo5marGJuYNw==", "1f93ab89-ab6d-413a-b8eb-21701ff808a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ba7413d-6ed3-4a27-b3e9-ef42b8802fb1", "AQAAAAIAAYagAAAAEL+0EQbXyczTmc9ET6PCiBItHYAVndFvpfNPUON+KjGqpexKsA8cfnsFCx7BsWcMYQ==", "d6bdea21-6abb-44e5-b85d-1e2f2d0a41ed" });
        }
    }
}
