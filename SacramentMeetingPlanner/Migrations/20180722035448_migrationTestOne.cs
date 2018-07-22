using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class migrationTestOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bishopric",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameID = table.Column<int>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    ReleasedFlag = table.Column<bool>(nullable: true),
                    MemberID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bishopric", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bishopric_Speakers_NameID",
                        column: x => x.NameID,
                        principalTable: "Speakers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ConductingID = table.Column<int>(nullable: true),
                    OpeningPrayerID = table.Column<int>(nullable: true),
                    OpeningSongID = table.Column<int>(nullable: true),
                    SacramentSongID = table.Column<int>(nullable: true),
                    OptIntermSongID = table.Column<int>(nullable: true),
                    ClosingPrayerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plans_Speakers_ClosingPrayerID",
                        column: x => x.ClosingPrayerID,
                        principalTable: "Speakers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_Bishopric_ConductingID",
                        column: x => x.ConductingID,
                        principalTable: "Bishopric",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_Speakers_OpeningPrayerID",
                        column: x => x.OpeningPrayerID,
                        principalTable: "Speakers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_Songs_OpeningSongID",
                        column: x => x.OpeningSongID,
                        principalTable: "Songs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_Songs_OptIntermSongID",
                        column: x => x.OptIntermSongID,
                        principalTable: "Songs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_Songs_SacramentSongID",
                        column: x => x.SacramentSongID,
                        principalTable: "Songs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpeakToPlan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpeakerToPlanId = table.Column<int>(nullable: false),
                    SpeakerNameID = table.Column<int>(nullable: true),
                    SpeakerPlacement = table.Column<int>(nullable: false),
                    SubjectID = table.Column<int>(nullable: true),
                    PlansID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakToPlan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpeakToPlan_Plans_PlansID",
                        column: x => x.PlansID,
                        principalTable: "Plans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpeakToPlan_Speakers_SpeakerNameID",
                        column: x => x.SpeakerNameID,
                        principalTable: "Speakers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpeakToPlan_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bishopric_NameID",
                table: "Bishopric",
                column: "NameID");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ClosingPrayerID",
                table: "Plans",
                column: "ClosingPrayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ConductingID",
                table: "Plans",
                column: "ConductingID");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_OpeningPrayerID",
                table: "Plans",
                column: "OpeningPrayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_OpeningSongID",
                table: "Plans",
                column: "OpeningSongID");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_OptIntermSongID",
                table: "Plans",
                column: "OptIntermSongID");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_SacramentSongID",
                table: "Plans",
                column: "SacramentSongID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakToPlan_PlansID",
                table: "SpeakToPlan",
                column: "PlansID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakToPlan_SpeakerNameID",
                table: "SpeakToPlan",
                column: "SpeakerNameID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakToPlan_SubjectID",
                table: "SpeakToPlan",
                column: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpeakToPlan");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Bishopric");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
