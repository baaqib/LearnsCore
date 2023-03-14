using Microsoft.EntityFrameworkCore.Migrations;

namespace Learns.Model.Migrations
{
    public partial class topics_mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SubjectID",
                table: "Topics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_SubjectID",
                table: "Topics",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Subjects_SubjectID",
                table: "Topics",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Subjects_SubjectID",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_SubjectID",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Topics");
        }
    }
}
