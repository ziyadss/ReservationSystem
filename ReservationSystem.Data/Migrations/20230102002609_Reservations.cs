using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Reservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_HolderId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_HolderId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_HolderUserName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "HolderId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "HolderUserName",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolderUserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HolderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_HolderId",
                        column: x => x.HolderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReservationId",
                table: "Tickets",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HolderId",
                table: "Reservations",
                column: "HolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HolderUserName",
                table: "Reservations",
                column: "HolderUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Reservations_ReservationId",
                table: "Tickets",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Reservations_ReservationId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ReservationId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "HolderId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HolderUserName",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17f5eb16-1caf-43f1-a06d-1d1666644b0d", "AQAAAAIAAYagAAAAEGwcwxceAN3E4OrcRi/JPu4ybVhInPVsoEQL2e+dOcpg19o16xluI/h8Mn4zkR+sXA==", "280a33ad-e6f8-4430-9775-33afdf548448" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e305d487-1418-4aa3-bee0-7dde7d488cf4", "AQAAAAIAAYagAAAAEFV0WGXKCtEhsqt3NPL9OYVgh4DHCg+0w/R+zQxPL/KdjF1Khrgw6C9Icmd3U8tHzg==", "4fe43a16-ecdd-4e65-9431-7504f5302e60" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_HolderId",
                table: "Tickets",
                column: "HolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_HolderUserName",
                table: "Tickets",
                column: "HolderUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_HolderId",
                table: "Tickets",
                column: "HolderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
