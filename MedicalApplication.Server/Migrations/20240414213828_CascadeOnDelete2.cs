using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class CascadeOnDelete2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDepartments_Doctors_DoctorId",
                table: "DoctorDepartments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eaefd4f-283d-42b2-9525-ebb31e67a07f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dae22da9-f94d-4e25-b6b0-d40cba812984");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa7f7ada-0b8a-4ce0-ba11-218f9971c7b4", null, "client", "CLIENT" },
                    { "ee6d99af-8ab7-49a5-85f6-b96ccd5d535b", null, "admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDepartments_Doctors_DoctorId",
                table: "DoctorDepartments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDepartments_Doctors_DoctorId",
                table: "DoctorDepartments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa7f7ada-0b8a-4ce0-ba11-218f9971c7b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6d99af-8ab7-49a5-85f6-b96ccd5d535b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1eaefd4f-283d-42b2-9525-ebb31e67a07f", null, "admin", "ADMIN" },
                    { "dae22da9-f94d-4e25-b6b0-d40cba812984", null, "client", "CLIENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDepartments_Doctors_DoctorId",
                table: "DoctorDepartments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
