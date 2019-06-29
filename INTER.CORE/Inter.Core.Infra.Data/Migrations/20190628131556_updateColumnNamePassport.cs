using Microsoft.EntityFrameworkCore.Migrations;

namespace Inter.Core.Infra.Data.Migrations
{
    public partial class updateColumnNamePassport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassaportNumber",
                table: "Student",
                newName: "PassportNumber");

            migrationBuilder.RenameColumn(
                name: "PassaportDateOfIssue",
                table: "Student",
                newName: "PassportDateOfIssue");

            migrationBuilder.RenameColumn(
                name: "PassaportDateOfExpiry",
                table: "Student",
                newName: "PassportDateOfExpiry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassportNumber",
                table: "Student",
                newName: "PassaportNumber");

            migrationBuilder.RenameColumn(
                name: "PassportDateOfIssue",
                table: "Student",
                newName: "PassaportDateOfIssue");

            migrationBuilder.RenameColumn(
                name: "PassportDateOfExpiry",
                table: "Student",
                newName: "PassaportDateOfExpiry");
        }
    }
}
