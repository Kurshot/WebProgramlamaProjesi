using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H12Auth2C.Data.Migrations
{
    public partial class k100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityImage",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityImage",
                table: "Cities");
        }
    }
}
