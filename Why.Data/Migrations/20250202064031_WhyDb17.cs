using Microsoft.EntityFrameworkCore.Migrations;

namespace Why.Data.Migrations
{
    public partial class WhyDb17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDataJson",
                table: "Biographies");

            migrationBuilder.AddColumn<string>(
                name: "ImagePaths",
                table: "Biographies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePaths",
                table: "Biographies");

            migrationBuilder.AddColumn<string>(
                name: "ImageDataJson",
                table: "Biographies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
