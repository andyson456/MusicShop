using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicShop.Data.Migrations
{
    public partial class DrumsAndRecordingsDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Recording",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Drum",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Recording");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Drum");
        }
    }
}
