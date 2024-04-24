using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class Get_all_DeptDoctors_With_SP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             var Sql_procedure = @"Create PROCEDURE Get_all_DeptDoctors_With_SP
                        AS 
                        SELECT [d].[Id], [d].[DepartmentId], [d].[Description], [d].[Education],
                        [d].[Email], [d].[Experience], [d].[Fee], [d].[ImageURL], [d].[Name] as [DocName], [d].[Phone],
                        [d].[Surname], [d].[Title], [d0].[name] as [DeptName],[d0].[details] as [DeptDetails]
						from Doctors as [d]
						Inner join [Departments] as [d0]
						on
						[d].[DepartmentId]=[d0].[Id]";

            migrationBuilder.Sql(Sql_procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
