using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aicupper.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Judges",
                columns: table => new
                {
                    JudgeID = table.Column<string>(nullable: false),
                    AICupperAccountID = table.Column<Guid>(nullable: false),
                    JudgeName = table.Column<string>(nullable: false),
                    KnownAs = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judges", x => x.JudgeID);
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
                    judgeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuppingEvents", x => x.CuppingEventID);
                    table.ForeignKey(
                        name: "FK_CuppingEvents_Judges_judgeId",
                        column: x => x.judgeId,
                        principalTable: "Judges",
                        principalColumn: "JudgeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuppingEvents_judgeId",
                table: "CuppingEvents",
                column: "judgeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuppingEvents");

            migrationBuilder.DropTable(
                name: "Judges");
        }
    }
}
