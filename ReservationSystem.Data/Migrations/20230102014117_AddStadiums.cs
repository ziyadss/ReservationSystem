using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStadiums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Name", "Columns", "Rows" },
                values: new object[,]
                {
                    { "Ahmad bin Ali Stadium", 16, 8 },
                    { "Al Bayt Stadium", 4, 2 },
                    { "Al Janoub Stadium", 512, 256 },
                    { "Al Thumama Stadium", 128, 64 },
                    { "Education City Stadium", 64, 32 },
                    { "Khalifa International Stadium", 8, 4 },
                    { "Lusail Stadium", 2, 1 },
                    { "Stadium 974", 256, 128 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Ahmad bin Ali Stadium");

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Al Bayt Stadium");

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Al Janoub Stadium");

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Al Thumama Stadium");

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Education City Stadium");

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Khalifa International Stadium");

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Lusail Stadium");

            migrationBuilder.DeleteData(
                table: "Stadiums",
                keyColumn: "Name",
                keyValue: "Stadium 974");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a9a506b-f8ea-4ea5-8e57-d93619821996", "AQAAAAIAAYagAAAAED76nfq2wylGYsrRjwvrP30RKPbQi4cn+o96/yEBQPOpxiNdL6j4scbJCP7dAZ/urw==", "8d1a4376-8974-4920-a2f5-b6a7234e476e" });
        }
    }
}
