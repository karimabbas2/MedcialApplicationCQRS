using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class EditDoctorName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDepartments_Doctors_DoctorIDId",
                table: "DoctorDepartments");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DoctorIDId",
                table: "DoctorDepartments",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorDepartments_DoctorIDId",
                table: "DoctorDepartments",
                newName: "IX_DoctorDepartments_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDepartments_Doctors_DoctorId",
                table: "DoctorDepartments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorDepartments_Doctors_DoctorId",
                table: "DoctorDepartments");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "DoctorDepartments",
                newName: "DoctorIDId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorDepartments_DoctorId",
                table: "DoctorDepartments",
                newName: "IX_DoctorDepartments_DoctorIDId");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorDepartments_Doctors_DoctorIDId",
                table: "DoctorDepartments",
                column: "DoctorIDId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
