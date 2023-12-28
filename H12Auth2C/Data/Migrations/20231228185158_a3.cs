using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H12Auth2C.Data.Migrations
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId1",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_UserId1",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Ticket",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId1",
                table: "Ticket",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId1",
                table: "Ticket",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
