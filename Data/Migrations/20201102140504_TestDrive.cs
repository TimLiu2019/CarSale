using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSale.Data.Migrations
{
    public partial class TestDrive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestDrive_CarModel_CarId",
                table: "TestDrive");

            migrationBuilder.DropIndex(
                name: "IX_TestDrive_CarId",
                table: "TestDrive");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "TestDrive");

            migrationBuilder.RenameColumn(
                name: "isUsed",
                table: "CarModel",
                newName: "IsUsed");

            migrationBuilder.AddColumn<int>(
                name: "TestDriveId",
                table: "CarModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_TestDriveId",
                table: "CarModel",
                column: "TestDriveId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_TestDrive_TestDriveId",
                table: "CarModel",
                column: "TestDriveId",
                principalTable: "TestDrive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_TestDrive_TestDriveId",
                table: "CarModel");

            migrationBuilder.DropIndex(
                name: "IX_CarModel_TestDriveId",
                table: "CarModel");

            migrationBuilder.DropColumn(
                name: "TestDriveId",
                table: "CarModel");

            migrationBuilder.RenameColumn(
                name: "IsUsed",
                table: "CarModel",
                newName: "isUsed");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "TestDrive",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestDrive_CarId",
                table: "TestDrive",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestDrive_CarModel_CarId",
                table: "TestDrive",
                column: "CarId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
