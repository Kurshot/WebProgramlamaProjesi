using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    public partial class a6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaneTypes_Planes_PlaneId",
                table: "PlaneTypes");

            migrationBuilder.DropIndex(
                name: "IX_PlaneTypes_PlaneId",
                table: "PlaneTypes");

            migrationBuilder.DropColumn(
                name: "PlaneId",
                table: "PlaneTypes");

            migrationBuilder.AddColumn<int>(
                name: "PlaneTypeId",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Planes_PlaneTypeId",
                table: "Planes",
                column: "PlaneTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_PlaneTypes_PlaneTypeId",
                table: "Planes",
                column: "PlaneTypeId",
                principalTable: "PlaneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planes_PlaneTypes_PlaneTypeId",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Planes_PlaneTypeId",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "PlaneTypeId",
                table: "Planes");

            migrationBuilder.AddColumn<int>(
                name: "PlaneId",
                table: "PlaneTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlaneTypes_PlaneId",
                table: "PlaneTypes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneTypes_Planes_PlaneId",
                table: "PlaneTypes",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
