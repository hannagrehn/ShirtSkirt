using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShirtSkirt.Migrations
{
    /// <inheritdoc />
    public partial class TablesUpdated_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Prices_PriceListPriceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PriceListPriceId",
                table: "Products",
                newName: "PriceListId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PriceListPriceId",
                table: "Products",
                newName: "IX_Products_PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Prices_PriceListId",
                table: "Products",
                column: "PriceListId",
                principalTable: "Prices",
                principalColumn: "PriceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Prices_PriceListId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PriceListId",
                table: "Products",
                newName: "PriceListPriceId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PriceListId",
                table: "Products",
                newName: "IX_Products_PriceListPriceId");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Prices_PriceListPriceId",
                table: "Products",
                column: "PriceListPriceId",
                principalTable: "Prices",
                principalColumn: "PriceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
