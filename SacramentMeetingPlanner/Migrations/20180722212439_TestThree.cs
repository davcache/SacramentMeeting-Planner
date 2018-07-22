using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class TestThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bishopric_Members_NameID",
                table: "Bishopric");

            migrationBuilder.DropIndex(
                name: "IX_Bishopric_NameID",
                table: "Bishopric");

            migrationBuilder.DropColumn(
                name: "NameID",
                table: "Bishopric");

            migrationBuilder.CreateIndex(
                name: "IX_Bishopric_MemberID",
                table: "Bishopric",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bishopric_Members_MemberID",
                table: "Bishopric",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bishopric_Members_MemberID",
                table: "Bishopric");

            migrationBuilder.DropIndex(
                name: "IX_Bishopric_MemberID",
                table: "Bishopric");

            migrationBuilder.AddColumn<int>(
                name: "NameID",
                table: "Bishopric",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bishopric_NameID",
                table: "Bishopric",
                column: "NameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bishopric_Members_NameID",
                table: "Bishopric",
                column: "NameID",
                principalTable: "Members",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
