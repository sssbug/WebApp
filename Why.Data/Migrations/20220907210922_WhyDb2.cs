using Microsoft.EntityFrameworkCore.Migrations;

namespace Why.Data.Migrations
{
    public partial class WhyDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thumbs_Users_UserId",
                table: "Thumbs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Thumbs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserssId",
                table: "Thumbs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Thumbs_Users_UserId",
                table: "Thumbs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thumbs_Users_UserId",
                table: "Thumbs");

            migrationBuilder.DropColumn(
                name: "UserssId",
                table: "Thumbs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Thumbs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Thumbs_Users_UserId",
                table: "Thumbs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
