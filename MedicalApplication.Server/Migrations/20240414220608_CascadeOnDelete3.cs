using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class CascadeOnDelete3 : Migration
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
                    { "45cd76e1-7c86-4e6b-b66e-a24630c1e735", null, "client", "CLIENT" },
                    { "8ec3e848-8e99-4887-b177-3aa2807e53ad", null, "admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDepartments_Doctors_DoctorId",
                table: "DoctorDepartments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                keyValue: "45cd76e1-7c86-4e6b-b66e-a24630c1e735");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ec3e848-8e99-4887-b177-3aa2807e53ad");

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
    }
}
