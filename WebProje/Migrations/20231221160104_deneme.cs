using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_arrivalPlaceIdId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_departurePlaceIdId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_arrivalPlaceIdId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_departurePlaceIdId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "arrivalPlaceIdId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "departurePlaceIdId",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "ArrivalPlaceId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeparturePlaceId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalPlaceId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DeparturePlaceId",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "arrivalPlaceIdId",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "departurePlaceIdId",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_arrivalPlaceIdId",
                table: "Flights",
                column: "arrivalPlaceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_departurePlaceIdId",
                table: "Flights",
                column: "departurePlaceIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_arrivalPlaceIdId",
                table: "Flights",
                column: "arrivalPlaceIdId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_departurePlaceIdId",
                table: "Flights",
                column: "departurePlaceIdId",
                principalTable: "Airports",
                principalColumn: "Id");
        }
    }
}
