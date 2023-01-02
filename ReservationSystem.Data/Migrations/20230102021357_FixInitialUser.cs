using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixInitialUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10c3abc9-44df-4c12-9f2d-a69007dd61eb", "AQAAAAIAAYagAAAAELMgSY26QN/8nZYYcl70tiGLuRoYeEPFmrpgnNol0iw5fhra3YCngsP0Fe+VHfpRiQ==", "47e9f505-356f-42e0-a517-277a1496f202" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-manager",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bedbde2f-4d30-42ba-b006-16f2226169ab", "AQAAAAIAAYagAAAAEN9NahKveMn7ayewvi/zvFQo/sDnQqJFN8U1Kt4JUNUXWdNUg5ZTwdnS2Q/MbguhgA==", "0631d74f-02f8-4cbc-b386-326587eae6f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "initial-user",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "234aea38-e004-41a5-ab6e-af5de1fc4159", "initialuser@domain.com", "INITIALUSER@DOMAIN.COM", "AQAAAAIAAYagAAAAEE5havsovoSXAFCdra6u+HNNlxCYl4lydw7h3XcJe7IK3AR+g+mrcSHuRxzN82XP7g==", "b0c3ccb1-9c17-4fb9-ba08-ca3f1a55c612" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5677558c-5eb9-40fc-b722-cf39bdceb4f4", "initialmanager@domain.com", "INITIALMANAGER@DOMAIN.COM", "AQAAAAIAAYagAAAAEC8D1HOG1LJpXhlwGPt7WSho0OeIgqegxANItnExhFH2bYDPTH57NZ464EevIs2+WA==", "cc9ca8f2-3cff-4fa9-99e8-fca1467b05f5" });
        }
    }
}
