using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardingKennelBookings.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Kennels_KennelID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_KennelID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "KennelID",
                table: "Bookings");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingID",
                table: "Kennels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KennelIDs",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_BookingID",
                table: "Kennels",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kennels_Bookings_BookingID",
                table: "Kennels",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "BookingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kennels_Bookings_BookingID",
                table: "Kennels");

            migrationBuilder.DropIndex(
                name: "IX_Kennels_BookingID",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "Kennels");

            migrationBuilder.DropColumn(
                name: "KennelIDs",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "KennelID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_KennelID",
                table: "Bookings",
                column: "KennelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Kennels_KennelID",
                table: "Bookings",
                column: "KennelID",
                principalTable: "Kennels",
                principalColumn: "KennelID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
