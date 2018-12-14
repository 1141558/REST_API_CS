using Microsoft.EntityFrameworkCore.Migrations;

namespace nucleocs.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Restrictions");

            migrationBuilder.RenameColumn(
                name: "dimensionType",
                table: "Products",
                newName: "DimensionType");

            migrationBuilder.RenameColumn(
                name: "required",
                table: "Aggregations",
                newName: "Required");

            migrationBuilder.AddColumn<int>(
                name: "objectToAlgoritm",
                table: "Restrictions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "objectToAlgoritm",
                table: "Restrictions");

            migrationBuilder.RenameColumn(
                name: "DimensionType",
                table: "Products",
                newName: "dimensionType");

            migrationBuilder.RenameColumn(
                name: "Required",
                table: "Aggregations",
                newName: "required");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Restrictions",
                nullable: true);
        }
    }
}
