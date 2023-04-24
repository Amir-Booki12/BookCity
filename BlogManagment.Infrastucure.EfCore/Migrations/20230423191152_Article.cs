using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagment.Infrastucure.EfCore.Migrations
{
    public partial class Article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PictureTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Keyword = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    MetaDesctiption = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    CannicalAddress = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
