using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSale.Data.Migrations
{
    public partial class add_isUsed_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isUsed",
                table: "CarModel",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isUsed",
                table: "CarModel");
        }
    }
}
