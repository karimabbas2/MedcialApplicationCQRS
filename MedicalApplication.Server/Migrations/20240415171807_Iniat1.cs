using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class Iniat1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f6e0706-ab55-43ba-a1be-5e57288d1984");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a619c50f-927e-4531-b02a-507d810053d2");

            migrationBuilder.DropColumn(
                name: "DepartmetnId",
                table: "Doctors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d1e4da6-090a-448a-96c7-cae6a8072608", null, "admin", "ADMIN" },
                    { "2d408698-ce0b-4996-b241-d230ff5b7125", null, "client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d1e4da6-090a-448a-96c7-cae6a8072608");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d408698-ce0b-4996-b241-d230ff5b7125");

            migrationBuilder.AddColumn<string>(
                name: "DepartmetnId",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f6e0706-ab55-43ba-a1be-5e57288d1984", null, "client", "CLIENT" },
                    { "a619c50f-927e-4531-b02a-507d810053d2", null, "admin", "ADMIN" }
                });
        }
    }
}
