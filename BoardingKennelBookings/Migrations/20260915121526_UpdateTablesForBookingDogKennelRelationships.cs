using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardingKennelBookings.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablesForBookingDogKennelRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDog");

            migrationBuilder.DropTable(
                name: "BookingKennel");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDogKennel_BookingID",
                table: "BookingDogKennel",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDogKennel_Bookings_BookingID",
                table: "BookingDogKennel",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDogKennel_Bookings_BookingID",
                table: "BookingDogKennel");

            migrationBuilder.DropIndex(
                name: "IX_BookingDogKennel_BookingID",
                table: "BookingDogKennel");

            migrationBuilder.CreateTable(
                name: "BookingDog",
                columns: table => new
                {
                    BookingsBookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDog", x => new { x.BookingsBookingID, x.DogsID });
                    table.ForeignKey(
                        name: "FK_BookingDog_Bookings_BookingsBookingID",
                        column: x => x.BookingsBookingID,
                        principalTable: "Bookings",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDog_Dogs_DogsID",
                        column: x => x.DogsID,
                        principalTable: "Dogs",
                        principalColumn: "ID");
                });

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
                name: "IX_BookingDog_DogsID",
                table: "BookingDog",
                column: "DogsID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingKennel_KennelsKennelID",
                table: "BookingKennel",
                column: "KennelsKennelID");
        }
    }
}
