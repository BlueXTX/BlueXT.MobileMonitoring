using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueXT.MobileMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class DeviceEventEntityCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_device_event",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp without time zone", nullable: false),
                    deviceid = table.Column<Guid>(name: "device_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_device_event", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_device_event");
        }
    }
}
