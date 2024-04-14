using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class CascadeOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDepartments_Departments_DepartmentId",
                table: "DoctorDepartments");

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
                    { "1eaefd4f-283d-42b2-9525-ebb31e67a07f", null, "admin", "ADMIN" },
                    { "dae22da9-f94d-4e25-b6b0-d40cba812984", null, "client", "CLIENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDepartments_Departments_DepartmentId",
                table: "DoctorDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDepartments_Departments_DepartmentId",
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
                    { "3243d2de-156a-4b80-8c1b-fe6cd01d6e70", null, "client", "CLIENT" },
                    { "d0d1c237-2498-46a6-b14f-3c4d5c74df20", null, "admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDepartments_Departments_DepartmentId",
                table: "DoctorDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
