using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bishopric_Members_MemberID",
                table: "Bishopric");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Members_ClosingPrayerID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Bishopric_ConductingID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Members_OpeningPrayerID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Songs_OpeningSongID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Songs_OptIntermSongID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Songs_SacramentSongID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakToPlan_Members_SpeakerNameID",
                table: "SpeakToPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakToPlan_Subjects_SubjectID",
                table: "SpeakToPlan");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_SpeakToPlan_SpeakerNameID",
                table: "SpeakToPlan");

            migrationBuilder.DropIndex(
                name: "IX_Plans_ClosingPrayerID",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_ConductingID",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_OpeningPrayerID",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_OpeningSongID",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_OptIntermSongID",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "SpeakerNameID",
                table: "SpeakToPlan");

            migrationBuilder.DropColumn(
                name: "SpeakerPlacement",
                table: "SpeakToPlan");

            migrationBuilder.DropColumn(
                name: "SpeakerToPlanId",
                table: "SpeakToPlan");

            migrationBuilder.DropColumn(
                name: "ClosingPrayerID",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ConductingID",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "OpeningPrayerID",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "OpeningSongID",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "OptIntermSongID",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Bishopric");

            migrationBuilder.RenameColumn(
                name: "SubjectID",
                table: "SpeakToPlan",
                newName: "SpeakAssignmentSpeakerAssignmentID");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakToPlan_SubjectID",
                table: "SpeakToPlan",
                newName: "IX_SpeakToPlan_SpeakAssignmentSpeakerAssignmentID");

            migrationBuilder.RenameColumn(
                name: "SacramentSongID",
                table: "Plans",
                newName: "BishopricID");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Plans",
                newName: "PlanDate");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Plans",
                newName: "PlansID");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_SacramentSongID",
                table: "Plans",
                newName: "IX_Plans_BishopricID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Bishopric",
                newName: "BishopricID");

            migrationBuilder.AlterColumn<bool>(
                name: "ReleasedFlag",
                table: "Bishopric",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Bishopric",
                nullable: true);

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
                    PrayerTypeID = table.Column<int>(nullable: true),
                    MemberID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prayer", x => x.PrayerID);
                    table.ForeignKey(
                        name: "FK_Prayer_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prayer_PrayerType_PrayerTypeID",
                        column: x => x.PrayerTypeID,
                        principalTable: "PrayerType",
                        principalColumn: "PrayerTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongAssignment",
                columns: table => new
                {
                    SongAssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SongID = table.Column<int>(nullable: true),
                    SongTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongAssignment", x => x.SongAssignmentID);
                    table.ForeignKey(
                        name: "FK_SongAssignment_Song_SongID",
                        column: x => x.SongID,
                        principalTable: "Song",
                        principalColumn: "SongID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongAssignment_SongType_SongTypeID",
                        column: x => x.SongTypeID,
                        principalTable: "SongType",
                        principalColumn: "SongTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpeakAssignment",
                columns: table => new
                {
                    SpeakerAssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: true),
                    SubjectID = table.Column<int>(nullable: true),
                    SpeakerPlacement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakAssignment", x => x.SpeakerAssignmentID);
                    table.ForeignKey(
                        name: "FK_SpeakAssignment_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpeakAssignment_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrayerToPlan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlansID = table.Column<int>(nullable: true),
                    PrayerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayerToPlan", x => x.ID);
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
                });

            migrationBuilder.CreateTable(
                name: "SongToPlan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlansID = table.Column<int>(nullable: true),
                    SongAssignmentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongToPlan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SongToPlan_Plans_PlansID",
                        column: x => x.PlansID,
                        principalTable: "Plans",
                        principalColumn: "PlansID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongToPlan_SongAssignment_SongAssignmentID",
                        column: x => x.SongAssignmentID,
                        principalTable: "SongAssignment",
                        principalColumn: "SongAssignmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bishopric_RoleID",
                table: "Bishopric",
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
                name: "IX_PrayerToPlan_PlansID",
                table: "PrayerToPlan",
                column: "PlansID");

            migrationBuilder.CreateIndex(
                name: "IX_PrayerToPlan_PrayerID",
                table: "PrayerToPlan",
                column: "PrayerID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bishopric_Member_MemberID",
                table: "Bishopric",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bishopric_Role_RoleID",
                table: "Bishopric",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Bishopric_BishopricID",
                table: "Plans",
                column: "BishopricID",
                principalTable: "Bishopric",
                principalColumn: "BishopricID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakToPlan_SpeakAssignment_SpeakAssignmentSpeakerAssignmentID",
                table: "SpeakToPlan",
                column: "SpeakAssignmentSpeakerAssignmentID",
                principalTable: "SpeakAssignment",
                principalColumn: "SpeakerAssignmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bishopric_Member_MemberID",
                table: "Bishopric");

            migrationBuilder.DropForeignKey(
                name: "FK_Bishopric_Role_RoleID",
                table: "Bishopric");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Bishopric_BishopricID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakToPlan_SpeakAssignment_SpeakAssignmentSpeakerAssignmentID",
                table: "SpeakToPlan");

            migrationBuilder.DropTable(
                name: "PrayerToPlan");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "SongToPlan");

            migrationBuilder.DropTable(
                name: "SpeakAssignment");

            migrationBuilder.DropTable(
                name: "Prayer");

            migrationBuilder.DropTable(
                name: "SongAssignment");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "PrayerType");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "SongType");

            migrationBuilder.DropIndex(
                name: "IX_Bishopric_RoleID",
                table: "Bishopric");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Bishopric");

            migrationBuilder.RenameColumn(
                name: "SpeakAssignmentSpeakerAssignmentID",
                table: "SpeakToPlan",
                newName: "SubjectID");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakToPlan_SpeakAssignmentSpeakerAssignmentID",
                table: "SpeakToPlan",
                newName: "IX_SpeakToPlan_SubjectID");

            migrationBuilder.RenameColumn(
                name: "PlanDate",
                table: "Plans",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "BishopricID",
                table: "Plans",
                newName: "SacramentSongID");

            migrationBuilder.RenameColumn(
                name: "PlansID",
                table: "Plans",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_BishopricID",
                table: "Plans",
                newName: "IX_Plans_SacramentSongID");

            migrationBuilder.RenameColumn(
                name: "BishopricID",
                table: "Bishopric",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "SpeakerNameID",
                table: "SpeakToPlan",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerPlacement",
                table: "SpeakToPlan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerToPlanId",
                table: "SpeakToPlan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClosingPrayerID",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConductingID",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpeningPrayerID",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpeningSongID",
                table: "Plans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptIntermSongID",
                table: "Plans",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ReleasedFlag",
                table: "Bishopric",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Bishopric",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SpeakToPlan_SpeakerNameID",
                table: "SpeakToPlan",
                column: "SpeakerNameID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bishopric_Members_MemberID",
                table: "Bishopric",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Members_ClosingPrayerID",
                table: "Plans",
                column: "ClosingPrayerID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Bishopric_ConductingID",
                table: "Plans",
                column: "ConductingID",
                principalTable: "Bishopric",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Members_OpeningPrayerID",
                table: "Plans",
                column: "OpeningPrayerID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Songs_OpeningSongID",
                table: "Plans",
                column: "OpeningSongID",
                principalTable: "Songs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Songs_OptIntermSongID",
                table: "Plans",
                column: "OptIntermSongID",
                principalTable: "Songs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Songs_SacramentSongID",
                table: "Plans",
                column: "SacramentSongID",
                principalTable: "Songs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakToPlan_Members_SpeakerNameID",
                table: "SpeakToPlan",
                column: "SpeakerNameID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakToPlan_Subjects_SubjectID",
                table: "SpeakToPlan",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
