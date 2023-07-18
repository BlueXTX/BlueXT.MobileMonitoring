using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueXT.MobileMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class DeviceStatisticRenameSnakeCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpFeatureGroups");

            migrationBuilder.DropTable(
                name: "AbpFeatures");

            migrationBuilder.DropTable(
                name: "AbpFeatureValues");

            migrationBuilder.DropTable(
                name: "AbpTenantConnectionStrings");

            migrationBuilder.DropTable(
                name: "AbpTenants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppDeviceStatistic",
                table: "AppDeviceStatistic");

            migrationBuilder.RenameTable(
                name: "AppDeviceStatistic",
                newName: "app_device_statistic");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "app_device_statistic",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "app_device_statistic",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OperatingSystem",
                table: "app_device_statistic",
                newName: "operating_system");

            migrationBuilder.RenameColumn(
                name: "LastModifierId",
                table: "app_device_statistic",
                newName: "last_modifier_id");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "app_device_statistic",
                newName: "last_modification_time");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "app_device_statistic",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "app_device_statistic",
                newName: "device_id");

            migrationBuilder.RenameColumn(
                name: "DeletionTime",
                table: "app_device_statistic",
                newName: "deletion_time");

            migrationBuilder.RenameColumn(
                name: "DeleterId",
                table: "app_device_statistic",
                newName: "deleter_id");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "app_device_statistic",
                newName: "creator_id");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "app_device_statistic",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "AppVersion",
                table: "app_device_statistic",
                newName: "app_version");

            migrationBuilder.AddPrimaryKey(
                name: "PK_app_device_statistic",
                table: "app_device_statistic",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_app_device_statistic_device_id",
                table: "app_device_statistic",
                column: "device_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_app_device_statistic_id",
                table: "app_device_statistic",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_app_device_statistic",
                table: "app_device_statistic");

            migrationBuilder.DropIndex(
                name: "IX_app_device_statistic_device_id",
                table: "app_device_statistic");

            migrationBuilder.DropIndex(
                name: "IX_app_device_statistic_id",
                table: "app_device_statistic");

            migrationBuilder.RenameTable(
                name: "app_device_statistic",
                newName: "AppDeviceStatistic");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "AppDeviceStatistic",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AppDeviceStatistic",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "operating_system",
                table: "AppDeviceStatistic",
                newName: "OperatingSystem");

            migrationBuilder.RenameColumn(
                name: "last_modifier_id",
                table: "AppDeviceStatistic",
                newName: "LastModifierId");

            migrationBuilder.RenameColumn(
                name: "last_modification_time",
                table: "AppDeviceStatistic",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "AppDeviceStatistic",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "device_id",
                table: "AppDeviceStatistic",
                newName: "DeviceId");

            migrationBuilder.RenameColumn(
                name: "deletion_time",
                table: "AppDeviceStatistic",
                newName: "DeletionTime");

            migrationBuilder.RenameColumn(
                name: "deleter_id",
                table: "AppDeviceStatistic",
                newName: "DeleterId");

            migrationBuilder.RenameColumn(
                name: "creator_id",
                table: "AppDeviceStatistic",
                newName: "CreatorId");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                table: "AppDeviceStatistic",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "app_version",
                table: "AppDeviceStatistic",
                newName: "AppVersion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppDeviceStatistic",
                table: "AppDeviceStatistic",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AbpFeatureGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatureGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AllowedProviders = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    DefaultValue = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    DisplayName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    GroupName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    IsAvailableToHost = table.Column<bool>(type: "boolean", nullable: false),
                    IsVisibleToClients = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    ValueType = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpFeatureValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    ProviderName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Value = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatureValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EntityVersion = table.Column<int>(type: "integer", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenantConnectionStrings",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Value = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenantConnectionStrings", x => new { x.TenantId, x.Name });
                    table.ForeignKey(
                        name: "FK_AbpTenantConnectionStrings_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatureGroups_Name",
                table: "AbpFeatureGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_GroupName",
                table: "AbpFeatures",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_Name",
                table: "AbpFeatures",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatureValues_Name_ProviderName_ProviderKey",
                table: "AbpFeatureValues",
                columns: new[] { "Name", "ProviderName", "ProviderKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_Name",
                table: "AbpTenants",
                column: "Name");
        }
    }
}
