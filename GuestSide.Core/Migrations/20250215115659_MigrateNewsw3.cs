using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class MigrateNewsw3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementTypes_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "AdvertisementTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioResponses_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_LanguagePacks_LanguagePackId",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_LanguagePacks_LanguagePackId",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCategories_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCategories_LanguagePacks_LanguagePackId",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_LanguagePacks_LanguagePackId",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomCategories_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "RoomCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffCategories_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "StaffCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Statuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatus_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "TaskStatus");

            migrationBuilder.DropIndex(
                name: "IX_TaskStatus_LanguageId",
                schema: "CSI",
                table: "TaskStatus");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_LanguageId",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_LanguageId",
                schema: "CSI",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_StaffCategories_LanguageId",
                schema: "CSI",
                table: "StaffCategories");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_LanguageId",
                schema: "CSI",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_RoomCategories_LanguageId",
                schema: "CSI",
                table: "RoomCategories");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_LanguageId",
                schema: "CSI",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Items_LanguageId",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_LanguagePackId",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategories_LanguageId",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategories_LanguagePackId",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_LanguageId",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_LanguagePackId",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_LanguageId",
                schema: "CSI",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Carts_LanguageId",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_LanguagePackId",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_AudioResponses_LanguageId",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementTypes_LanguageId",
                schema: "CSI",
                table: "AdvertisementTypes");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_LanguageId",
                schema: "CSI",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "TaskStatus");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "StaffCategories");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "RoomCategories");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LanguagePackId",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "LanguagePackId",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "LanguagePackId",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "LanguagePackId",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "AdvertisementTypes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Advertisements");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "TaskStatus",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Tasks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Statuses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Rooms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "RoomCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "PaymentOptions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Notifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "ItemCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Hotels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Feedbacks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Carts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "AudioResponses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "AdvertisementTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StaffSupports",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AttachmentUrls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffSupports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffSupports_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "CSI",
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffSupportResponses",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    ResponderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFromSupportTeam = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentUrls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffSupportResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffSupportResponses_StaffSupports_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "CSI",
                        principalTable: "StaffSupports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_LanguageCode",
                schema: "CSI",
                table: "Items",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LanguageCode",
                schema: "CSI",
                table: "Carts",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupportResponses_TicketId",
                schema: "CSI",
                table: "StaffSupportResponses",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupports_StaffId",
                schema: "CSI",
                table: "StaffSupports",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Guests",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "StaffSupportResponses",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffSupports",
                schema: "CSI");

            migrationBuilder.DropIndex(
                name: "IX_Items_LanguageCode",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Carts_LanguageCode",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "TaskStatus");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "RoomCategories");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "PaymentOptions");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "AdvertisementTypes");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Advertisements");

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "TaskStatus",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Statuses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "StaffCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Rooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "RoomCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Notifications",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Items",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguagePackId",
                schema: "CSI",
                table: "Items",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "ItemCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguagePackId",
                schema: "CSI",
                table: "ItemCategories",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Hotels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguagePackId",
                schema: "CSI",
                table: "Hotels",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Feedbacks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Carts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguagePackId",
                schema: "CSI",
                table: "Carts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "AudioResponses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "AdvertisementTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Advertisements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatus_LanguageId",
                schema: "CSI",
                table: "TaskStatus",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LanguageId",
                schema: "CSI",
                table: "Tasks",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_LanguageId",
                schema: "CSI",
                table: "Statuses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCategories_LanguageId",
                schema: "CSI",
                table: "StaffCategories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LanguageId",
                schema: "CSI",
                table: "Rooms",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_LanguageId",
                schema: "CSI",
                table: "RoomCategories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_LanguageId",
                schema: "CSI",
                table: "Notifications",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LanguageId",
                schema: "CSI",
                table: "Items",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LanguagePackId",
                schema: "CSI",
                table: "Items",
                column: "LanguagePackId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_LanguageId",
                schema: "CSI",
                table: "ItemCategories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_LanguagePackId",
                schema: "CSI",
                table: "ItemCategories",
                column: "LanguagePackId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LanguageId",
                schema: "CSI",
                table: "Hotels",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LanguagePackId",
                schema: "CSI",
                table: "Hotels",
                column: "LanguagePackId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_LanguageId",
                schema: "CSI",
                table: "Feedbacks",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LanguageId",
                schema: "CSI",
                table: "Carts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LanguagePackId",
                schema: "CSI",
                table: "Carts",
                column: "LanguagePackId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_LanguageId",
                schema: "CSI",
                table: "AudioResponses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementTypes_LanguageId",
                schema: "CSI",
                table: "AdvertisementTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_LanguageId",
                schema: "CSI",
                table: "Advertisements",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Advertisements",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementTypes_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "AdvertisementTypes",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioResponses_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "AudioResponses",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Carts",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_LanguagePacks_LanguagePackId",
                schema: "CSI",
                table: "Carts",
                column: "LanguagePackId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Feedbacks",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Guests",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Hotels",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_LanguagePacks_LanguagePackId",
                schema: "CSI",
                table: "Hotels",
                column: "LanguagePackId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCategories_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "ItemCategories",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCategories_LanguagePacks_LanguagePackId",
                schema: "CSI",
                table: "ItemCategories",
                column: "LanguagePackId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Items",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_LanguagePacks_LanguagePackId",
                schema: "CSI",
                table: "Items",
                column: "LanguagePackId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Notifications",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCategories_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "RoomCategories",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Rooms",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffCategories_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "StaffCategories",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Statuses",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Tasks",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatus_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "TaskStatus",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
