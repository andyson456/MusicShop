using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicShop.Data.Migrations
{
    public partial class GuitarDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Guitar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Guitar");
        }
    }
}
