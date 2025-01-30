using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Why.Data.Migrations
{
    public partial class WhyDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    UserLastName = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Thumbs",
                columns: table => new
                {
                    ThumbId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThumbName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thumbs", x => x.ThumbId);
                    table.ForeignKey(
                        name: "FK_Thumbs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Thumbs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biographies",
                columns: table => new
                {
                    BiographyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiographyUserName = table.Column<string>(nullable: true),
                    BiographyTitle = table.Column<string>(nullable: true),
                    BiographyContent = table.Column<string>(nullable: true),
                    UsersId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ThumbId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biographies", x => x.BiographyId);
                    table.ForeignKey(
                        name: "FK_Biographies_Thumbs_ThumbId",
                        column: x => x.ThumbId,
                        principalTable: "Thumbs",
                        principalColumn: "ThumbId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Biographies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biographies_ThumbId",
                table: "Biographies",
                column: "ThumbId");

            migrationBuilder.CreateIndex(
                name: "IX_Biographies_UserId",
                table: "Biographies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Thumbs_CategoryId",
                table: "Thumbs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Thumbs_UserId",
                table: "Thumbs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biographies");

            migrationBuilder.DropTable(
                name: "Thumbs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
