using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inter.Core.Infra.Data.Migrations
{
    public partial class includedDestinationWithFKInAnothersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DestinationId",
                table: "Student",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationId",
                table: "CulturalExchange",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationId",
                table: "college",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DestinationId",
                table: "Accomodation",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Student_DestinationId",
                table: "Student",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_CulturalExchange_DestinationId",
                table: "CulturalExchange",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_college_DestinationId",
                table: "college",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accomodation_DestinationId",
                table: "Accomodation",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accomodation_Destination_DestinationId",
                table: "Accomodation",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_college_Destination_DestinationId",
                table: "college",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CulturalExchange_Destination_DestinationId",
                table: "CulturalExchange",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Destination_DestinationId",
                table: "Student",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accomodation_Destination_DestinationId",
                table: "Accomodation");

            migrationBuilder.DropForeignKey(
                name: "FK_college_Destination_DestinationId",
                table: "college");

            migrationBuilder.DropForeignKey(
                name: "FK_CulturalExchange_Destination_DestinationId",
                table: "CulturalExchange");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Destination_DestinationId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_DestinationId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_CulturalExchange_DestinationId",
                table: "CulturalExchange");

            migrationBuilder.DropIndex(
                name: "IX_college_DestinationId",
                table: "college");

            migrationBuilder.DropIndex(
                name: "IX_Accomodation_DestinationId",
                table: "Accomodation");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "CulturalExchange");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "college");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Accomodation");
        }
    }
}
