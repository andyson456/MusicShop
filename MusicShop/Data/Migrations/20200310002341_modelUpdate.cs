using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicShop.Data.Migrations
{
    public partial class modelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Recording",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Drum",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Recording");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Drum");
        }
    }
}
