using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelPMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHousekeepingEnhancements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedStaffId",
                table: "HousekeepingTasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "HousekeepingTasks",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasMaintenanceIssue",
                table: "HousekeepingTasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MaintenanceIssueDescription",
                table: "HousekeepingTasks",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedStaffId",
                table: "HousekeepingTasks");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "HousekeepingTasks");

            migrationBuilder.DropColumn(
                name: "HasMaintenanceIssue",
                table: "HousekeepingTasks");

            migrationBuilder.DropColumn(
                name: "MaintenanceIssueDescription",
                table: "HousekeepingTasks");
        }
    }
}
