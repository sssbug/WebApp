using Microsoft.EntityFrameworkCore.Migrations;

namespace Why.Data.Migrations
{
    public partial class WhyDb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbLastName",
                table: "Thumbs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbTag",
                table: "Thumbs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbLastName",
                table: "Thumbs");

            migrationBuilder.DropColumn(
                name: "ThumbTag",
                table: "Thumbs");
        }
    }
}
