using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagment.Infrastucure.EfCore.Migrations
{
    public partial class Blog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Keyword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CannicalAddress = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");
        }
    }
}
