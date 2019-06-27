using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inter.Core.Infra.Data.Migrations
{
    public partial class IncludedTablePaymentCulturalExchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentCulturalExchange",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    DateOfPayment = table.Column<DateTime>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CulturalExchangeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCulturalExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentCulturalExchange_CulturalExchange_CulturalExchangeId",
                        column: x => x.CulturalExchangeId,
                        principalTable: "CulturalExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentCulturalExchange_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCulturalExchange_CulturalExchangeId",
                table: "PaymentCulturalExchange",
                column: "CulturalExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCulturalExchange_EnvironmentId",
                table: "PaymentCulturalExchange",
                column: "EnvironmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentCulturalExchange");
        }
    }
}
