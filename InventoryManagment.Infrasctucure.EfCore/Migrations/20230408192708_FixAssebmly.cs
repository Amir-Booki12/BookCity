using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagment.Infrasctucure.EfCore.Migrations
{
    public partial class FixAssebmly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryOperation_Inventory_InventoryId",
                table: "InventoryOperation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryOperation",
                table: "InventoryOperation");

            migrationBuilder.RenameTable(
                name: "InventoryOperation",
                newName: "OperationInventory");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryOperation_InventoryId",
                table: "OperationInventory",
                newName: "IX_OperationInventory_InventoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "OperationInventory",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationInventory",
                table: "OperationInventory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationInventory_Inventory_InventoryId",
                table: "OperationInventory",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationInventory_Inventory_InventoryId",
                table: "OperationInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationInventory",
                table: "OperationInventory");

            migrationBuilder.RenameTable(
                name: "OperationInventory",
                newName: "InventoryOperation");

            migrationBuilder.RenameIndex(
                name: "IX_OperationInventory_InventoryId",
                table: "InventoryOperation",
                newName: "IX_InventoryOperation_InventoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InventoryOperation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryOperation",
                table: "InventoryOperation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryOperation_Inventory_InventoryId",
                table: "InventoryOperation",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
