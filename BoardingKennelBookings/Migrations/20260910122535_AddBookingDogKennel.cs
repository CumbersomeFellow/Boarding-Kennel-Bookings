using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardingKennelBookings.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingDogKennel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingDogKennel",
                columns: table => new
                {
                    BookingDogKennelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KennelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDogKennel", x => x.BookingDogKennelID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDogKennel");
        }
    }
}
