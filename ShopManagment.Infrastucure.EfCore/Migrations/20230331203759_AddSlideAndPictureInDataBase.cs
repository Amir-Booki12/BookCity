using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagment.Infrastucure.EfCore.Migrations
{
    public partial class AddSlideAndPictureInDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPictures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Header = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BtnText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_ProductId",
                table: "ProductPictures",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropTable(
                name: "Slides");
        }
    }
}
