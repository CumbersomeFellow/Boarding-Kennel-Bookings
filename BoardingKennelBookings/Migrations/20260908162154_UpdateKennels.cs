using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardingKennelBookings.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKennels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BookingKennel",
                columns: table => new
                {
                    BookingsBookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KennelsKennelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingKennel", x => new { x.BookingsBookingID, x.KennelsKennelID });
                    table.ForeignKey(
                        name: "FK_BookingKennel_Bookings_BookingsBookingID",
                        column: x => x.BookingsBookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingKennel_Kennels_KennelsKennelID",
                        column: x => x.KennelsKennelID,
                        principalTable: "Kennels",
                        principalColumn: "KennelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingKennel_KennelsKennelID",
                table: "BookingKennel",
                column: "KennelsKennelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingKennel");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingID",
                table: "Kennels",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
