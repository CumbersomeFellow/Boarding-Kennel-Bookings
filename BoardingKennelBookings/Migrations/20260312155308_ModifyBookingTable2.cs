using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardingKennelBookings.Migrations
{
    /// <inheritdoc />
    public partial class ModifyBookingTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AMDropoff",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PMDropoff",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AMDropoff",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PMDropoff",
                table: "Bookings");
        }
    }
}
