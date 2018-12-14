using Microsoft.EntityFrameworkCore.Migrations;

namespace nucleocs.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aggregations_Products_ProductFatherId",
                table: "Aggregations");

            migrationBuilder.CreateIndex(
                name: "IX_Aggregations_ProductSonId",
                table: "Aggregations",
                column: "ProductSonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aggregations_Products_ProductSonId",
                table: "Aggregations",
                column: "ProductSonId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aggregations_Products_ProductSonId",
                table: "Aggregations");

            migrationBuilder.DropIndex(
                name: "IX_Aggregations_ProductSonId",
                table: "Aggregations");

            migrationBuilder.AddForeignKey(
                name: "FK_Aggregations_Products_ProductFatherId",
                table: "Aggregations",
                column: "ProductFatherId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
