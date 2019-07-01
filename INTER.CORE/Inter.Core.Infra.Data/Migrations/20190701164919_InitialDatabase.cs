using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inter.Core.Infra.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Environment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    CompanyCode = table.Column<string>(maxLength: 10, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accomodation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    ContactName = table.Column<string>(maxLength: 30, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 13, nullable: false),
                    NumberOfPlaces = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accomodation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accomodation_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.Id);
                    table.ForeignKey(
                        name: "FK_College_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<string>(maxLength: 10, nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 13, nullable: false),
                    DateOfBirthday = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(maxLength: 10, nullable: false),
                    PassportDateOfIssue = table.Column<DateTime>(nullable: false),
                    PassportDateOfExpiry = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollegeTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    FinishTime = table.Column<TimeSpan>(nullable: false),
                    DaysOfWeek = table.Column<int>(nullable: false),
                    TimeForWeek = table.Column<int>(nullable: false),
                    Period = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    BookPrice = table.Column<decimal>(type: "decimal(6,4)", nullable: false),
                    ExamPrice = table.Column<decimal>(nullable: false),
                    InsurancePrice = table.Column<decimal>(nullable: false),
                    AccomodationPrice = table.Column<decimal>(nullable: false),
                    NetPrice = table.Column<decimal>(nullable: false),
                    GrossPrice = table.Column<decimal>(nullable: false),
                    PercentagePrice = table.Column<int>(nullable: false),
                    CollegeId = table.Column<Guid>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollegeTime_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CulturalExchange",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    CollegeId = table.Column<Guid>(nullable: false),
                    CollegeTimeId = table.Column<Guid>(nullable: false),
                    AccomodationId = table.Column<Guid>(nullable: false),
                    WeekNumber = table.Column<int>(nullable: false),
                    DaysOfAccomodation = table.Column<int>(nullable: false),
                    StartAccomodation = table.Column<DateTime>(nullable: false),
                    FinishAccomodation = table.Column<DateTime>(nullable: false),
                    INSUR = table.Column<bool>(nullable: false),
                    Transfer = table.Column<bool>(nullable: false),
                    Support = table.Column<bool>(nullable: false),
                    Kit = table.Column<bool>(nullable: false),
                    SimCard = table.Column<bool>(nullable: false),
                    OurAccomodation = table.Column<bool>(nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Company = table.Column<string>(maxLength: 20, nullable: false),
                    FlightNumber = table.Column<string>(maxLength: 10, nullable: false),
                    CollegePayment = table.Column<bool>(nullable: false),
                    TotalValue = table.Column<float>(nullable: false),
                    SalesMen = table.Column<string>(maxLength: 30, nullable: false),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CulturalExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CulturalExchange_Accomodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalTable: "Accomodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CulturalExchange_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CulturalExchange_CollegeTime_CollegeTimeId",
                        column: x => x.CollegeTimeId,
                        principalTable: "CollegeTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CulturalExchange_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CulturalExchange_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CulturalExchangeFileUpload",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CulturalExchangeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CulturalExchangeFileUpload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CulturalExchangeFileUpload_CulturalExchange_CulturalExchange~",
                        column: x => x.CulturalExchangeId,
                        principalTable: "CulturalExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ReceivePaymentCulturalExchange",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    DateOfPayment = table.Column<DateTime>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CulturalExchangeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivePaymentCulturalExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivePaymentCulturalExchange_CulturalExchange_CulturalExch~",
                        column: x => x.CulturalExchangeId,
                        principalTable: "CulturalExchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceivePaymentCulturalExchange_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accomodation_EnvironmentId",
                table: "Accomodation",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EnvironmentId",
                table: "AspNetUsers",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_College_EnvironmentId",
                table: "College",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeTime_CollegeId",
                table: "CollegeTime",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CulturalExchange_AccomodationId",
                table: "CulturalExchange",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_CulturalExchange_CollegeId",
                table: "CulturalExchange",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CulturalExchange_CollegeTimeId",
                table: "CulturalExchange",
                column: "CollegeTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_CulturalExchange_EnvironmentId",
                table: "CulturalExchange",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CulturalExchange_StudentId",
                table: "CulturalExchange",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CulturalExchangeFileUpload_CulturalExchangeId",
                table: "CulturalExchangeFileUpload",
                column: "CulturalExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCulturalExchange_CulturalExchangeId",
                table: "PaymentCulturalExchange",
                column: "CulturalExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCulturalExchange_EnvironmentId",
                table: "PaymentCulturalExchange",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivePaymentCulturalExchange_CulturalExchangeId",
                table: "ReceivePaymentCulturalExchange",
                column: "CulturalExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivePaymentCulturalExchange_EnvironmentId",
                table: "ReceivePaymentCulturalExchange",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_EnvironmentId",
                table: "Student",
                column: "EnvironmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CulturalExchangeFileUpload");

            migrationBuilder.DropTable(
                name: "PaymentCulturalExchange");

            migrationBuilder.DropTable(
                name: "ReceivePaymentCulturalExchange");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CulturalExchange");

            migrationBuilder.DropTable(
                name: "Accomodation");

            migrationBuilder.DropTable(
                name: "CollegeTime");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "College");

            migrationBuilder.DropTable(
                name: "Environment");
        }
    }
}
