using Microsoft.EntityFrameworkCore.Migrations;

namespace nucleocs.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Aggregations_Products_ProductFatherId",
                table: "Aggregations",
                column: "ProductFatherId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aggregations_Products_ProductFatherId",
                table: "Aggregations");
        }
    }
}
