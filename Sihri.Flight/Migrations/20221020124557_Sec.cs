using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sihri.Flight.Migrations
{
    public partial class Sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservedFlights_AspNetUsers_FlightUserId",
                table: "ReservedFlights");

            migrationBuilder.DropIndex(
                name: "IX_ReservedFlights_FlightUserId",
                table: "ReservedFlights");

            migrationBuilder.DropColumn(
                name: "FlightUserId",
                table: "ReservedFlights");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ReservedFlights",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ReservedFlights_UserId",
                table: "ReservedFlights",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedFlights_AspNetUsers_UserId",
                table: "ReservedFlights",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservedFlights_AspNetUsers_UserId",
                table: "ReservedFlights");

            migrationBuilder.DropIndex(
                name: "IX_ReservedFlights_UserId",
                table: "ReservedFlights");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReservedFlights");

            migrationBuilder.AddColumn<Guid>(
                name: "FlightUserId",
                table: "ReservedFlights",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservedFlights_FlightUserId",
                table: "ReservedFlights",
                column: "FlightUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedFlights_AspNetUsers_FlightUserId",
                table: "ReservedFlights",
                column: "FlightUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
