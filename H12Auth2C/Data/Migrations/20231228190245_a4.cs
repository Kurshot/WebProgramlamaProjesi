using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H12Auth2C.Data.Migrations
{
    public partial class a4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ticketType",
                table: "Ticket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ticketType",
                table: "Ticket",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
