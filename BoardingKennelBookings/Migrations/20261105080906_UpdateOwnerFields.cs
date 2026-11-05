using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardingKennelBookings.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOwnerFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TownCity",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "TownCity",
                table: "Owners");
        }
    }
}
