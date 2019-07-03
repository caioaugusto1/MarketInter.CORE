using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inter.Core.Infra.Data.Migrations
{
    public partial class UpdateColumnsNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CulturalExchange_Accomodation_AccomodationId",
                table: "CulturalExchange");

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "CulturalExchange",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "CulturalExchange",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalDateTime",
                table: "CulturalExchange",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccomodationId",
                table: "CulturalExchange",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_CulturalExchange_Accomodation_AccomodationId",
                table: "CulturalExchange",
                column: "AccomodationId",
                principalTable: "Accomodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CulturalExchange_Accomodation_AccomodationId",
                table: "CulturalExchange");

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "CulturalExchange",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "CulturalExchange",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalDateTime",
                table: "CulturalExchange",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccomodationId",
                table: "CulturalExchange",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CulturalExchange_Accomodation_AccomodationId",
                table: "CulturalExchange",
                column: "AccomodationId",
                principalTable: "Accomodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
