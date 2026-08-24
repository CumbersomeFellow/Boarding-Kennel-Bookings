using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardingKennelBookings.Migrations
{
    /// <inheritdoc />
    public partial class ModifyBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DogIDs",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "KennelIDs",
                table: "Bookings");

            migrationBuilder.AddColumn<bool>(
                name: "AMPickup",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PMPickup",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AMPickup",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PMPickup",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "DogIDs",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KennelIDs",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
