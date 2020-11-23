using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSale.Data.Migrations
{
    public partial class HomeImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slide1 = table.Column<string>(nullable: true),
                    Slide2 = table.Column<string>(nullable: true),
                    Slide3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeImage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeImage");
        }
    }
}
