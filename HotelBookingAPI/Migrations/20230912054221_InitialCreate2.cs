using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hotelBookings",
                table: "hotelBookings");

            migrationBuilder.RenameTable(
                name: "hotelBookings",
                newName: "HotelBookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckinDateTime",
                table: "HotelBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutDateTime",
                table: "HotelBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBookings",
                table: "HotelBookings",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBookings",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "CheckinDateTime",
                table: "HotelBookings");

            migrationBuilder.DropColumn(
                name: "CheckoutDateTime",
                table: "HotelBookings");

            migrationBuilder.RenameTable(
                name: "HotelBookings",
                newName: "hotelBookings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotelBookings",
                table: "hotelBookings",
                column: "Id");
        }
    }
}
