using Microsoft.EntityFrameworkCore.Migrations;

namespace GridMVC.Migrations
{
    public partial class roomnuminbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomNum",
                schema: "Hotel",
                table: "RoomBoking",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomNum",
                schema: "Hotel",
                table: "RoomBoking");
        }
    }
}
