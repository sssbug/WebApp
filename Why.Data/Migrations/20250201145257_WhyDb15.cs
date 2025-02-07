using Microsoft.EntityFrameworkCore.Migrations;

namespace Why.Data.Migrations
{
    public partial class WhyDb15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagesJson",
                table: "Biographies");

            migrationBuilder.AddColumn<string>(
                name: "ImageJson",
                table: "Biographies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageJson",
                table: "Biographies");

            migrationBuilder.AddColumn<string>(
                name: "ImagesJson",
                table: "Biographies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
