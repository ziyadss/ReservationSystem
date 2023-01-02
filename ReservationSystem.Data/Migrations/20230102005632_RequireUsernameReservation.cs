using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RequireUsernameReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HolderUserName",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HolderUserName",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28214ec6-dbea-4fb6-9174-e2820e4b14c4", "AQAAAAIAAYagAAAAEJL3Aml3TzatYng7x7Aig2Q65HzsexMAE/ChPYmv6z1H+8c0btVmHcyj0PPpNgW43Q==", "e4b518b3-a867-48ce-96bd-c8a184707433" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "886f1196-2690-42d3-b853-2bc9153af5f8", "AQAAAAIAAYagAAAAED//6kWLxikHCpbYeYE5NcgIE8mSdJEUHLk4tUXVQP4er4F8j5uB2gqlv9eZi0IcWg==", "0adaeeca-81ed-473e-9c06-1504e718debf" });
        }
    }
}
