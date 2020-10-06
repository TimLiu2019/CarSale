using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSale.Data.Migrations
{
    public partial class carImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pictureId",
                table: "CarModel");

            migrationBuilder.AddColumn<string>(
                name: "CarImage",
                table: "CarModel",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarImage",
                table: "CarModel");

            migrationBuilder.AddColumn<string>(
                name: "pictureId",
                table: "CarModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
