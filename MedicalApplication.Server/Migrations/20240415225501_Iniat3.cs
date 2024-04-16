using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class Iniat3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d1e4da6-090a-448a-96c7-cae6a8072608");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d408698-ce0b-4996-b241-d230ff5b7125");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4329b7ba-9468-4f69-9a4b-85beb4b0b8a9", null, "client", "CLIENT" },
                    { "f7396d0e-ff83-438c-9961-bddca28a9c70", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4329b7ba-9468-4f69-9a4b-85beb4b0b8a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7396d0e-ff83-438c-9961-bddca28a9c70");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d1e4da6-090a-448a-96c7-cae6a8072608", null, "admin", "ADMIN" },
                    { "2d408698-ce0b-4996-b241-d230ff5b7125", null, "client", "CLIENT" }
                });
        }
    }
}
