using Microsoft.EntityFrameworkCore.Migrations;

namespace nucleocs.Migrations
{
    public partial class update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aggregations_Products_ProductSProductId",
                table: "Aggregations");

            migrationBuilder.DropForeignKey(
                name: "FK_Aggregations_Products_ProductSonId",
                table: "Aggregations");

            migrationBuilder.DropIndex(
                name: "IX_Aggregations_ProductSProductId",
                table: "Aggregations");

            migrationBuilder.DropColumn(
                name: "ProductSProductId",
                table: "Aggregations");

            migrationBuilder.AddForeignKey(
                name: "FK_Aggregations_Products_ProductFatherId",
                table: "Aggregations",
                column: "ProductFatherId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aggregations_Products_ProductSonId",
                table: "Aggregations",
                column: "ProductSonId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aggregations_Products_ProductFatherId",
                table: "Aggregations");

            migrationBuilder.DropForeignKey(
                name: "FK_Aggregations_Products_ProductSonId",
                table: "Aggregations");

            migrationBuilder.AddColumn<int>(
                name: "ProductSProductId",
                table: "Aggregations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aggregations_ProductSProductId",
                table: "Aggregations",
                column: "ProductSProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aggregations_Products_ProductSProductId",
                table: "Aggregations",
                column: "ProductSProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aggregations_Products_ProductSonId",
                table: "Aggregations",
                column: "ProductSonId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
