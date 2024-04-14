using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6483a54-d74f-42d6-b086-48c4a56af00a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdad21d2-21f4-4092-a4c7-cc77b5749227");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3243d2de-156a-4b80-8c1b-fe6cd01d6e70", null, "client", "CLIENT" },
                    { "d0d1c237-2498-46a6-b14f-3c4d5c74df20", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3243d2de-156a-4b80-8c1b-fe6cd01d6e70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0d1c237-2498-46a6-b14f-3c4d5c74df20");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b6483a54-d74f-42d6-b086-48c4a56af00a", null, "client", "CLIENT" },
                    { "fdad21d2-21f4-4092-a4c7-cc77b5749227", null, "admin", "ADMIN" }
                });
        }
    }
}
