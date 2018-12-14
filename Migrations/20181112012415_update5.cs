using Microsoft.EntityFrameworkCore.Migrations;

namespace nucleocs.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restrictions_Aggregations_AggregationProductFatherId_AggregationProductSonId",
                table: "Restrictions");

            migrationBuilder.RenameColumn(
                name: "objectToAlgoritm",
                table: "Restrictions",
                newName: "ObjectToAlgoritm");

            migrationBuilder.AddForeignKey(
                name: "FK_Restrictions_Aggregations_AggregationProductFatherId_AggregationProductSonId",
                table: "Restrictions",
                columns: new[] { "AggregationProductFatherId", "AggregationProductSonId" },
                principalTable: "Aggregations",
                principalColumns: new[] { "ProductFatherId", "ProductSonId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restrictions_Aggregations_AggregationProductFatherId_AggregationProductSonId",
                table: "Restrictions");

            migrationBuilder.RenameColumn(
                name: "ObjectToAlgoritm",
                table: "Restrictions",
                newName: "objectToAlgoritm");

            migrationBuilder.AddForeignKey(
                name: "FK_Restrictions_Aggregations_AggregationProductFatherId_AggregationProductSonId",
                table: "Restrictions",
                columns: new[] { "AggregationProductFatherId", "AggregationProductSonId" },
                principalTable: "Aggregations",
                principalColumns: new[] { "ProductFatherId", "ProductSonId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
