using Microsoft.EntityFrameworkCore.Migrations;

namespace Inter.Core.Infra.Data.Migrations
{
    public partial class InsertRenewPriceInCollegeTimeAndInsertRenewInCulturalExchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RenewCourse",
                table: "CulturalExchange",
                newName: "Renew");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Renew",
                table: "CulturalExchange",
                newName: "RenewCourse");
        }
    }
}
