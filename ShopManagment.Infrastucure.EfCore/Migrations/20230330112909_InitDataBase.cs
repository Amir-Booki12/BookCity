using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagment.Infrastucure.EfCore.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescraption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
