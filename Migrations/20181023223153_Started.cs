using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aicupper.Migrations
{
    public partial class Started : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AICupperAccounts",
                columns: table => new
                {
                    AICupperCustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AICupperAccountID = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactPhoneNumber = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    SaltedPassword = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AICupperAccounts", x => x.AICupperCustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryCode = table.Column<string>(nullable: false),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "CuppingEvents",
                columns: table => new
                {
                    CuppingEventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AICupperAccountID = table.Column<Guid>(nullable: false),
                    NumberOfSamples = table.Column<int>(nullable: false),
                    NumberOfJudges = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    EventNotes = table.Column<string>(nullable: true),
                    EventLocation = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    AICupperAccountAICupperCustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuppingEvents", x => x.CuppingEventID);
                    table.ForeignKey(
                        name: "FK_CuppingEvents_AICupperAccounts_AICupperAccountAICupperCustomerID",
                        column: x => x.AICupperAccountAICupperCustomerID,
                        principalTable: "AICupperAccounts",
                        principalColumn: "AICupperCustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Judges",
                columns: table => new
                {
                    JudgeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AICupperAccountID = table.Column<Guid>(nullable: false),
                    JudgeName = table.Column<string>(nullable: false),
                    KnownAs = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    AICupperAccountAICupperCustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judges", x => x.JudgeID);
                    table.ForeignKey(
                        name: "FK_Judges_AICupperAccounts_AICupperAccountAICupperCustomerID",
                        column: x => x.AICupperAccountAICupperCustomerID,
                        principalTable: "AICupperAccounts",
                        principalColumn: "AICupperCustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JudgeCuppingEvents",
                columns: table => new
                {
                    JudgeEventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JudgeID = table.Column<int>(nullable: false),
                    AICupperAccountID = table.Column<Guid>(nullable: false),
                    CuppingEventID = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeCuppingEvents", x => x.JudgeEventID);
                    table.ForeignKey(
                        name: "FK_JudgeCuppingEvents_Judges_JudgeID",
                        column: x => x.JudgeID,
                        principalTable: "Judges",
                        principalColumn: "JudgeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuppingEvents_AICupperAccountAICupperCustomerID",
                table: "CuppingEvents",
                column: "AICupperAccountAICupperCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeCuppingEvents_JudgeID",
                table: "JudgeCuppingEvents",
                column: "JudgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Judges_AICupperAccountAICupperCustomerID",
                table: "Judges",
                column: "AICupperAccountAICupperCustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CuppingEvents");

            migrationBuilder.DropTable(
                name: "JudgeCuppingEvents");

            migrationBuilder.DropTable(
                name: "Judges");

            migrationBuilder.DropTable(
                name: "AICupperAccounts");
        }
    }
}
