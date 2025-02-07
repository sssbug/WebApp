using Microsoft.EntityFrameworkCore.Migrations;

namespace Why.Data.Migrations
{
    public partial class WhyDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biographies_Thumbs_ThumbId",
                table: "Biographies");

            migrationBuilder.AlterColumn<int>(
                name: "ThumbId",
                table: "Biographies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ThumbsId",
                table: "Biographies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Biographies_Thumbs_ThumbId",
                table: "Biographies",
                column: "ThumbId",
                principalTable: "Thumbs",
                principalColumn: "ThumbId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biographies_Thumbs_ThumbId",
                table: "Biographies");

            migrationBuilder.DropColumn(
                name: "ThumbsId",
                table: "Biographies");

            migrationBuilder.AlterColumn<int>(
                name: "ThumbId",
                table: "Biographies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Biographies_Thumbs_ThumbId",
                table: "Biographies",
                column: "ThumbId",
                principalTable: "Thumbs",
                principalColumn: "ThumbId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
