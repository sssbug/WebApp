using Microsoft.EntityFrameworkCore.Migrations;

namespace Why.Data.Migrations
{
    public partial class WhyDb11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageDataJson",
                table: "Biographies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDataJson",
                table: "Biographies");
        }
    }
}
