using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueXT.MobileMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AuditRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creation_time",
                table: "app_device_statistic");

            migrationBuilder.DropColumn(
                name: "creator_id",
                table: "app_device_statistic");

            migrationBuilder.DropColumn(
                name: "deleter_id",
                table: "app_device_statistic");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                table: "app_device_statistic");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "app_device_statistic");

            migrationBuilder.DropColumn(
                name: "last_modification_time",
                table: "app_device_statistic");

            migrationBuilder.DropColumn(
                name: "last_modifier_id",
                table: "app_device_statistic");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "creation_time",
                table: "app_device_statistic",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "creator_id",
                table: "app_device_statistic",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleter_id",
                table: "app_device_statistic",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                table: "app_device_statistic",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "app_device_statistic",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modification_time",
                table: "app_device_statistic",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "last_modifier_id",
                table: "app_device_statistic",
                type: "uuid",
                nullable: true);
        }
    }
}
