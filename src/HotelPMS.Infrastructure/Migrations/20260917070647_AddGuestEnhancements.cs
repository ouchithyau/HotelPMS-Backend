using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelPMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGuestEnhancements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Guests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlacklisted",
                table: "Guests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVip",
                table: "Guests",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "IsBlacklisted",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "IsVip",
                table: "Guests");
        }
    }
}
