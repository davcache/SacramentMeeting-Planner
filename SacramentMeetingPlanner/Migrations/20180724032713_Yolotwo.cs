using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
//Migrations page
namespace SacramentMeetingPlanner.Migrations
{
    public partial class Yolotwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "PrayerType",
                columns: table => new
                {
                    PrayerTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrayerTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayerType", x => x.PrayerTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SongName = table.Column<string>(nullable: true),
                    SongNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongID);
                });

            migrationBuilder.CreateTable(
                name: "SongType",
                columns: table => new
                {
                    SongTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SongTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongType", x => x.SongTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Prayer",
                columns: table => new
                {
                    PrayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrayerTypeID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prayer", x => x.PrayerID);
                    table.ForeignKey(
                        name: "FK_Prayer_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prayer_PrayerType_PrayerTypeID",
                        column: x => x.PrayerTypeID,
                        principalTable: "PrayerType",
                        principalColumn: "PrayerTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bishopric",
                columns: table => new
                {
                    BishopricID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false),
                    ReleasedFlag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bishopric", x => x.BishopricID);
                    table.ForeignKey(
                        name: "FK_Bishopric_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bishopric_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlansID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanDate = table.Column<DateTime>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlansID);
                    table.ForeignKey(
                        name: "FK_Plans_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongAssignment",
                columns: table => new
                {
                    SongAssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SongID = table.Column<int>(nullable: false),
                    SongTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongAssignment", x => x.SongAssignmentID);
                    table.ForeignKey(
                        name: "FK_SongAssignment_Song_SongID",
                        column: x => x.SongID,
                        principalTable: "Song",
                        principalColumn: "SongID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongAssignment_SongType_SongTypeID",
                        column: x => x.SongTypeID,
                        principalTable: "SongType",
                        principalColumn: "SongTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakAssignment",
                columns: table => new
                {
                    SpeakAssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: false),
                    SubjectID = table.Column<int>(nullable: false),
                    SpeakerPlacement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakAssignment", x => x.SpeakAssignmentID);
                    table.ForeignKey(
                        name: "FK_SpeakAssignment_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeakAssignment_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrayerToPlan",
                columns: table => new
                {
                    PrayerToPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlansID = table.Column<int>(nullable: true),
                    PrayerTypeID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false),
                    PrayerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayerToPlan", x => x.PrayerToPlanID);
                    table.ForeignKey(
                        name: "FK_PrayerToPlan_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrayerToPlan_Plans_PlansID",
                        column: x => x.PlansID,
                        principalTable: "Plans",
                        principalColumn: "PlansID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrayerToPlan_Prayer_PrayerID",
                        column: x => x.PrayerID,
                        principalTable: "Prayer",
                        principalColumn: "PrayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrayerToPlan_PrayerType_PrayerTypeID",
                        column: x => x.PrayerTypeID,
                        principalTable: "PrayerType",
                        principalColumn: "PrayerTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongToPlan",
                columns: table => new
                {
                    SongToPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlansID = table.Column<int>(nullable: false),
                    SongAssignmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongToPlan", x => x.SongToPlanID);
                    table.ForeignKey(
                        name: "FK_SongToPlan_Plans_PlansID",
                        column: x => x.PlansID,
                        principalTable: "Plans",
                        principalColumn: "PlansID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongToPlan_SongAssignment_SongAssignmentID",
                        column: x => x.SongAssignmentID,
                        principalTable: "SongAssignment",
                        principalColumn: "SongAssignmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakToPlan",
                columns: table => new
                {
                    SpeakToPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlansID = table.Column<int>(nullable: false),
                    SpeakAssignmentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakToPlan", x => x.SpeakToPlanID);
                    table.ForeignKey(
                        name: "FK_SpeakToPlan_Plans_PlansID",
                        column: x => x.PlansID,
                        principalTable: "Plans",
                        principalColumn: "PlansID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeakToPlan_SpeakAssignment_SpeakAssignmentID",
                        column: x => x.SpeakAssignmentID,
                        principalTable: "SpeakAssignment",
                        principalColumn: "SpeakAssignmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bishopric_MemberID",
                table: "Bishopric",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Bishopric_RoleID",
                table: "Bishopric",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_RoleID",
                table: "Plans",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Prayer_MemberID",
                table: "Prayer",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Prayer_PrayerTypeID",
                table: "Prayer",
                column: "PrayerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PrayerToPlan_MemberID",
                table: "PrayerToPlan",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_PrayerToPlan_PlansID",
                table: "PrayerToPlan",
                column: "PlansID");

            migrationBuilder.CreateIndex(
                name: "IX_PrayerToPlan_PrayerID",
                table: "PrayerToPlan",
                column: "PrayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PrayerToPlan_PrayerTypeID",
                table: "PrayerToPlan",
                column: "PrayerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SongAssignment_SongID",
                table: "SongAssignment",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_SongAssignment_SongTypeID",
                table: "SongAssignment",
                column: "SongTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SongToPlan_PlansID",
                table: "SongToPlan",
                column: "PlansID");

            migrationBuilder.CreateIndex(
                name: "IX_SongToPlan_SongAssignmentID",
                table: "SongToPlan",
                column: "SongAssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakAssignment_MemberID",
                table: "SpeakAssignment",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakAssignment_SubjectID",
                table: "SpeakAssignment",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakToPlan_PlansID",
                table: "SpeakToPlan",
                column: "PlansID");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakToPlan_SpeakAssignmentID",
                table: "SpeakToPlan",
                column: "SpeakAssignmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bishopric");

            migrationBuilder.DropTable(
                name: "PrayerToPlan");

            migrationBuilder.DropTable(
                name: "SongToPlan");

            migrationBuilder.DropTable(
                name: "SpeakToPlan");

            migrationBuilder.DropTable(
                name: "Prayer");

            migrationBuilder.DropTable(
                name: "SongAssignment");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "SpeakAssignment");

            migrationBuilder.DropTable(
                name: "PrayerType");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "SongType");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
