using Microsoft.EntityFrameworkCore.Migrations;

namespace _374Cloud.Migrations
{
    public partial class myFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "layer_level",
                table: "catalog_ref",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "layer_level",
                table: "catalog_ref");
        }
    }
}
