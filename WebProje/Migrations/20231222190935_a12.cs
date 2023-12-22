using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class a12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_departurePlaceId",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "arrivalPlaceId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_arrivalPlaceId",
                table: "Flights",
                column: "arrivalPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_arrivalPlaceId",
                table: "Flights",
                column: "arrivalPlaceId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_departurePlaceId",
                table: "Flights",
                column: "departurePlaceId",
                principalTable: "Airports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_arrivalPlaceId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_departurePlaceId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_arrivalPlaceId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "arrivalPlaceId",
                table: "Flights");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_departurePlaceId",
                table: "Flights",
                column: "departurePlaceId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
