using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShirtSkirt.Migrations
{
    /// <inheritdoc />
    public partial class TablesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryNameCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Descriptions_IngressDescriptionId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufactures_ManufactureNameManufactureId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Prices_PriceId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Reviews_ReviewTextReviewId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryNameCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IngressDescriptionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManufactureNameManufactureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PriceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryNameCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IngressDescriptionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManufactureNameManufactureId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ReviewTextReviewId",
                table: "Products",
                newName: "PriceListPriceId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ReviewTextReviewId",
                table: "Products",
                newName: "IX_Products_PriceListPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DescriptionId",
                table: "Products",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufactureId",
                table: "Products",
                column: "ManufactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReviewId",
                table: "Products",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Descriptions_DescriptionId",
                table: "Products",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "DescriptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufactures_ManufactureId",
                table: "Products",
                column: "ManufactureId",
                principalTable: "Manufactures",
                principalColumn: "ManufactureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Prices_PriceListPriceId",
                table: "Products",
                column: "PriceListPriceId",
                principalTable: "Prices",
                principalColumn: "PriceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Reviews_ReviewId",
                table: "Products",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Descriptions_DescriptionId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufactures_ManufactureId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Prices_PriceListPriceId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Reviews_ReviewId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DescriptionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManufactureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReviewId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PriceListPriceId",
                table: "Products",
                newName: "ReviewTextReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PriceListPriceId",
                table: "Products",
                newName: "IX_Products_ReviewTextReviewId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryNameCategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngressDescriptionId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManufactureNameManufactureId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryNameCategoryId",
                table: "Products",
                column: "CategoryNameCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IngressDescriptionId",
                table: "Products",
                column: "IngressDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufactureNameManufactureId",
                table: "Products",
                column: "ManufactureNameManufactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceId",
                table: "Products",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryNameCategoryId",
                table: "Products",
                column: "CategoryNameCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Descriptions_IngressDescriptionId",
                table: "Products",
                column: "IngressDescriptionId",
                principalTable: "Descriptions",
                principalColumn: "DescriptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufactures_ManufactureNameManufactureId",
                table: "Products",
                column: "ManufactureNameManufactureId",
                principalTable: "Manufactures",
                principalColumn: "ManufactureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Prices_PriceId",
                table: "Products",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "PriceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Reviews_ReviewTextReviewId",
                table: "Products",
                column: "ReviewTextReviewId",
                principalTable: "Reviews",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
