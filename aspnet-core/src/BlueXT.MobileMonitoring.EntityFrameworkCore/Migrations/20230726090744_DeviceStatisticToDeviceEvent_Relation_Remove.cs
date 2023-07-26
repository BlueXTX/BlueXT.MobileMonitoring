using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueXT.MobileMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class DeviceStatisticToDeviceEventRelationRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_app_device_event_app_device_statistic_device_statistic_id",
                table: "app_device_event");

            migrationBuilder.DropIndex(
                name: "IX_app_device_event_device_statistic_id",
                table: "app_device_event");

            migrationBuilder.RenameColumn(
                name: "device_statistic_id",
                table: "app_device_event",
                newName: "device_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "device_id",
                table: "app_device_event",
                newName: "device_statistic_id");

            migrationBuilder.CreateIndex(
                name: "IX_app_device_event_device_statistic_id",
                table: "app_device_event",
                column: "device_statistic_id");

            migrationBuilder.AddForeignKey(
                name: "FK_app_device_event_app_device_statistic_device_statistic_id",
                table: "app_device_event",
                column: "device_statistic_id",
                principalTable: "app_device_statistic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
