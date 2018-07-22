using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class testTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bishopric_Speakers_NameID",
                table: "Bishopric");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Speakers_ClosingPrayerID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Speakers_OpeningPrayerID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakToPlan_Speakers_SpeakerNameID",
                table: "SpeakToPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers");

            migrationBuilder.RenameTable(
                name: "Speakers",
                newName: "Members");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bishopric_Members_NameID",
                table: "Bishopric",
                column: "NameID",
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
                name: "FK_Plans_Members_OpeningPrayerID",
                table: "Plans",
                column: "OpeningPrayerID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakToPlan_Members_SpeakerNameID",
                table: "SpeakToPlan",
                column: "SpeakerNameID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bishopric_Members_NameID",
                table: "Bishopric");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Members_ClosingPrayerID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Members_OpeningPrayerID",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakToPlan_Members_SpeakerNameID",
                table: "SpeakToPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Speakers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bishopric_Speakers_NameID",
                table: "Bishopric",
                column: "NameID",
                principalTable: "Speakers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Speakers_ClosingPrayerID",
                table: "Plans",
                column: "ClosingPrayerID",
                principalTable: "Speakers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Speakers_OpeningPrayerID",
                table: "Plans",
                column: "OpeningPrayerID",
                principalTable: "Speakers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakToPlan_Speakers_SpeakerNameID",
                table: "SpeakToPlan",
                column: "SpeakerNameID",
                principalTable: "Speakers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
