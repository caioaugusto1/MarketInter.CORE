using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inter.Core.Infra.Data.Migrations
{
    public partial class CreateDestinationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destination_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destination_EnvironmentId",
                table: "Destination",
                column: "EnvironmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destination");
        }
    }
}
