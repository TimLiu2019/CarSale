using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSale.Data.Migrations
{
    public partial class add_price_mileage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "CarModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "CarModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "CarModel");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CarModel");
        }
    }
}
