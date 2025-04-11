using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class midfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_Rating",
                schema: "CSI",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_AudioResponses_CreatedDate",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_EndDate",
                schema: "CSI",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_StartDate",
                schema: "CSI",
                table: "Advertisements");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "TaskToStaffs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "TaskLogs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "TaskItems",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffSupports",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffSupportResponses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffSentiments",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Staffs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffReserveItems",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffNotifications",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffIncidents",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffCategories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Rooms",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Restaurants",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantOrderPayments",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantItemToCarts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantItems",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantItemCategories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantCarts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "QRCodes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "PromoCode",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Logs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Locations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "LanguagePacks",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "IncidentTypes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "GuestNotifications",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "CSI",
                table: "AudioResponses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "AudioResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "CSI",
                table: "AudioResponses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "AdvertisementTypes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Advertisements",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_CreatedAt",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_IsActive",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_LanguageCode",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedAt",
                schema: "CSI",
                table: "Tasks",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IsActive",
                schema: "CSI",
                table: "Tasks",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLogs_CreatedAt",
                schema: "CSI",
                table: "TaskLogs",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLogs_IsActive",
                schema: "CSI",
                table: "TaskLogs",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLogs_LanguageCode",
                schema: "CSI",
                table: "TaskLogs",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CreatedAt",
                schema: "CSI",
                table: "TaskItems",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_IsActive",
                schema: "CSI",
                table: "TaskItems",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_LanguageCode",
                schema: "CSI",
                table: "TaskItems",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_CreatedAt",
                schema: "CSI",
                table: "Statuses",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_IsActive",
                schema: "CSI",
                table: "Statuses",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupports_CreatedAt",
                schema: "CSI",
                table: "StaffSupports",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupports_IsActive",
                schema: "CSI",
                table: "StaffSupports",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupports_LanguageCode",
                schema: "CSI",
                table: "StaffSupports",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupportResponses_CreatedAt",
                schema: "CSI",
                table: "StaffSupportResponses",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupportResponses_IsActive",
                schema: "CSI",
                table: "StaffSupportResponses",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupportResponses_LanguageCode",
                schema: "CSI",
                table: "StaffSupportResponses",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSentiments_CreatedAt",
                schema: "CSI",
                table: "StaffSentiments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSentiments_IsActive",
                schema: "CSI",
                table: "StaffSentiments",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSentiments_LanguageCode",
                schema: "CSI",
                table: "StaffSentiments",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_CreatedAt",
                schema: "CSI",
                table: "Staffs",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_LanguageCode",
                schema: "CSI",
                table: "Staffs",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffReserveItems_CreatedAt",
                schema: "CSI",
                table: "StaffReserveItems",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StaffReserveItems_IsActive",
                schema: "CSI",
                table: "StaffReserveItems",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StaffReserveItems_LanguageCode",
                schema: "CSI",
                table: "StaffReserveItems",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffNotifications_CreatedAt",
                schema: "CSI",
                table: "StaffNotifications",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StaffNotifications_IsActive",
                schema: "CSI",
                table: "StaffNotifications",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StaffNotifications_LanguageCode",
                schema: "CSI",
                table: "StaffNotifications",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffIncidents_CreatedAt",
                schema: "CSI",
                table: "StaffIncidents",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StaffIncidents_IsActive",
                schema: "CSI",
                table: "StaffIncidents",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StaffIncidents_LanguageCode",
                schema: "CSI",
                table: "StaffIncidents",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCategories_LanguageCode",
                schema: "CSI",
                table: "StaffCategories",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAboutRanOutItems_CreatedAt",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAboutRanOutItems_IsActive",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAboutRanOutItems_LanguageCode",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IsActive",
                schema: "CSI",
                table: "Rooms",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LanguageCode",
                schema: "CSI",
                table: "Rooms",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_LanguageCode",
                schema: "CSI",
                table: "Restaurants",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrderPayments_CreatedAt",
                schema: "CSI",
                table: "RestaurantOrderPayments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrderPayments_IsActive",
                schema: "CSI",
                table: "RestaurantOrderPayments",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrderPayments_LanguageCode",
                schema: "CSI",
                table: "RestaurantOrderPayments",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemToCarts_IsActive",
                schema: "CSI",
                table: "RestaurantItemToCarts",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemToCarts_LanguageCode",
                schema: "CSI",
                table: "RestaurantItemToCarts",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItems_CreatedAt",
                schema: "CSI",
                table: "RestaurantItems",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItems_IsActive",
                schema: "CSI",
                table: "RestaurantItems",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItems_LanguageCode",
                schema: "CSI",
                table: "RestaurantItems",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemCategories_LanguageCode",
                schema: "CSI",
                table: "RestaurantItemCategories",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_IsActive",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_LanguageCode",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_QRCodes_CreatedAt",
                schema: "CSI",
                table: "QRCodes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_QRCodes_IsActive",
                schema: "CSI",
                table: "QRCodes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_QRCodes_LanguageCode",
                schema: "CSI",
                table: "QRCodes",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCode_CreatedAt",
                schema: "CSI",
                table: "PromoCode",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCode_IsActive",
                schema: "CSI",
                table: "PromoCode",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCode_LanguageCode",
                schema: "CSI",
                table: "PromoCode",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_CreatedAt",
                schema: "CSI",
                table: "PaymentOptions",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_IsActive",
                schema: "CSI",
                table: "PaymentOptions",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedAt",
                schema: "CSI",
                table: "Notifications",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IsActive",
                schema: "CSI",
                table: "Notifications",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CreatedAt",
                schema: "CSI",
                table: "Logs",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_IsActive",
                schema: "CSI",
                table: "Logs",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LanguageCode",
                schema: "CSI",
                table: "Logs",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CreatedAt",
                schema: "CSI",
                table: "Locations",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_IsActive",
                schema: "CSI",
                table: "Locations",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LanguageCode",
                schema: "CSI",
                table: "Locations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePacks_CreatedAt",
                schema: "CSI",
                table: "LanguagePacks",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePacks_IsActive",
                schema: "CSI",
                table: "LanguagePacks",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePacks_LanguageCode",
                schema: "CSI",
                table: "LanguagePacks",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CreatedAt",
                schema: "CSI",
                table: "Items",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Items_IsActive",
                schema: "CSI",
                table: "Items",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategoryToStaffCategory_CreatedAt",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategoryToStaffCategory_IsActive",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategoryToStaffCategory_LanguageCode",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_CreatedAt",
                schema: "CSI",
                table: "ItemCategories",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_IsActive",
                schema: "CSI",
                table: "ItemCategories",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypeToStaffCategories_CreatedAt",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypeToStaffCategories_IsActive",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypeToStaffCategories_LanguageCode",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_CreatedAt",
                schema: "CSI",
                table: "IncidentTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_IsActive",
                schema: "CSI",
                table: "IncidentTypes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_LanguageCode",
                schema: "CSI",
                table: "IncidentTypes",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CreatedAt",
                schema: "CSI",
                table: "Hotels",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_IsActive",
                schema: "CSI",
                table: "Hotels",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LanguageCode",
                schema: "CSI",
                table: "Hotels",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_CreatedAt",
                schema: "CSI",
                table: "Guests",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_IsActive",
                schema: "CSI",
                table: "Guests",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_LanguageCode",
                schema: "CSI",
                table: "Guests",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_GuestNotifications_CreatedAt",
                schema: "CSI",
                table: "GuestNotifications",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_GuestNotifications_IsActive",
                schema: "CSI",
                table: "GuestNotifications",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_GuestNotifications_LanguageCode",
                schema: "CSI",
                table: "GuestNotifications",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_GuestLanguages_CreatedAt",
                schema: "CSI",
                table: "GuestLanguages",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_GuestLanguages_IsActive",
                schema: "CSI",
                table: "GuestLanguages",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CreatedAt",
                schema: "CSI",
                table: "Feedbacks",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_IsActive",
                schema: "CSI",
                table: "Feedbacks",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CreatedAt",
                schema: "CSI",
                table: "Carts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IsActive",
                schema: "CSI",
                table: "Carts",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_CreatedAt",
                schema: "CSI",
                table: "AudioResponses",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_IsActive",
                schema: "CSI",
                table: "AudioResponses",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementTypes_CreatedAt",
                schema: "CSI",
                table: "AdvertisementTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementTypes_IsActive",
                schema: "CSI",
                table: "AdvertisementTypes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_CreatedAt",
                schema: "CSI",
                table: "Advertisements",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_IsActive",
                schema: "CSI",
                table: "Advertisements",
                column: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaskToStaffs_CreatedAt",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropIndex(
                name: "IX_TaskToStaffs_IsActive",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropIndex(
                name: "IX_TaskToStaffs_LanguageCode",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatedAt",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_IsActive",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskLogs_CreatedAt",
                schema: "CSI",
                table: "TaskLogs");

            migrationBuilder.DropIndex(
                name: "IX_TaskLogs_IsActive",
                schema: "CSI",
                table: "TaskLogs");

            migrationBuilder.DropIndex(
                name: "IX_TaskLogs_LanguageCode",
                schema: "CSI",
                table: "TaskLogs");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_CreatedAt",
                schema: "CSI",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_IsActive",
                schema: "CSI",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_LanguageCode",
                schema: "CSI",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_CreatedAt",
                schema: "CSI",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_IsActive",
                schema: "CSI",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_StaffSupports_CreatedAt",
                schema: "CSI",
                table: "StaffSupports");

            migrationBuilder.DropIndex(
                name: "IX_StaffSupports_IsActive",
                schema: "CSI",
                table: "StaffSupports");

            migrationBuilder.DropIndex(
                name: "IX_StaffSupports_LanguageCode",
                schema: "CSI",
                table: "StaffSupports");

            migrationBuilder.DropIndex(
                name: "IX_StaffSupportResponses_CreatedAt",
                schema: "CSI",
                table: "StaffSupportResponses");

            migrationBuilder.DropIndex(
                name: "IX_StaffSupportResponses_IsActive",
                schema: "CSI",
                table: "StaffSupportResponses");

            migrationBuilder.DropIndex(
                name: "IX_StaffSupportResponses_LanguageCode",
                schema: "CSI",
                table: "StaffSupportResponses");

            migrationBuilder.DropIndex(
                name: "IX_StaffSentiments_CreatedAt",
                schema: "CSI",
                table: "StaffSentiments");

            migrationBuilder.DropIndex(
                name: "IX_StaffSentiments_IsActive",
                schema: "CSI",
                table: "StaffSentiments");

            migrationBuilder.DropIndex(
                name: "IX_StaffSentiments_LanguageCode",
                schema: "CSI",
                table: "StaffSentiments");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_CreatedAt",
                schema: "CSI",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_LanguageCode",
                schema: "CSI",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_StaffReserveItems_CreatedAt",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropIndex(
                name: "IX_StaffReserveItems_IsActive",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropIndex(
                name: "IX_StaffReserveItems_LanguageCode",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropIndex(
                name: "IX_StaffNotifications_CreatedAt",
                schema: "CSI",
                table: "StaffNotifications");

            migrationBuilder.DropIndex(
                name: "IX_StaffNotifications_IsActive",
                schema: "CSI",
                table: "StaffNotifications");

            migrationBuilder.DropIndex(
                name: "IX_StaffNotifications_LanguageCode",
                schema: "CSI",
                table: "StaffNotifications");

            migrationBuilder.DropIndex(
                name: "IX_StaffIncidents_CreatedAt",
                schema: "CSI",
                table: "StaffIncidents");

            migrationBuilder.DropIndex(
                name: "IX_StaffIncidents_IsActive",
                schema: "CSI",
                table: "StaffIncidents");

            migrationBuilder.DropIndex(
                name: "IX_StaffIncidents_LanguageCode",
                schema: "CSI",
                table: "StaffIncidents");

            migrationBuilder.DropIndex(
                name: "IX_StaffCategories_LanguageCode",
                schema: "CSI",
                table: "StaffCategories");

            migrationBuilder.DropIndex(
                name: "IX_StaffAboutRanOutItems_CreatedAt",
                schema: "CSI",
                table: "StaffAboutRanOutItems");

            migrationBuilder.DropIndex(
                name: "IX_StaffAboutRanOutItems_IsActive",
                schema: "CSI",
                table: "StaffAboutRanOutItems");

            migrationBuilder.DropIndex(
                name: "IX_StaffAboutRanOutItems_LanguageCode",
                schema: "CSI",
                table: "StaffAboutRanOutItems");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_IsActive",
                schema: "CSI",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_LanguageCode",
                schema: "CSI",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_LanguageCode",
                schema: "CSI",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOrderPayments_CreatedAt",
                schema: "CSI",
                table: "RestaurantOrderPayments");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOrderPayments_IsActive",
                schema: "CSI",
                table: "RestaurantOrderPayments");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOrderPayments_LanguageCode",
                schema: "CSI",
                table: "RestaurantOrderPayments");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantItemToCarts_IsActive",
                schema: "CSI",
                table: "RestaurantItemToCarts");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantItemToCarts_LanguageCode",
                schema: "CSI",
                table: "RestaurantItemToCarts");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantItems_CreatedAt",
                schema: "CSI",
                table: "RestaurantItems");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantItems_IsActive",
                schema: "CSI",
                table: "RestaurantItems");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantItems_LanguageCode",
                schema: "CSI",
                table: "RestaurantItems");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantItemCategories_LanguageCode",
                schema: "CSI",
                table: "RestaurantItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantCarts_IsActive",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantCarts_LanguageCode",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropIndex(
                name: "IX_QRCodes_CreatedAt",
                schema: "CSI",
                table: "QRCodes");

            migrationBuilder.DropIndex(
                name: "IX_QRCodes_IsActive",
                schema: "CSI",
                table: "QRCodes");

            migrationBuilder.DropIndex(
                name: "IX_QRCodes_LanguageCode",
                schema: "CSI",
                table: "QRCodes");

            migrationBuilder.DropIndex(
                name: "IX_PromoCode_CreatedAt",
                schema: "CSI",
                table: "PromoCode");

            migrationBuilder.DropIndex(
                name: "IX_PromoCode_IsActive",
                schema: "CSI",
                table: "PromoCode");

            migrationBuilder.DropIndex(
                name: "IX_PromoCode_LanguageCode",
                schema: "CSI",
                table: "PromoCode");

            migrationBuilder.DropIndex(
                name: "IX_PaymentOptions_CreatedAt",
                schema: "CSI",
                table: "PaymentOptions");

            migrationBuilder.DropIndex(
                name: "IX_PaymentOptions_IsActive",
                schema: "CSI",
                table: "PaymentOptions");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_CreatedAt",
                schema: "CSI",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_IsActive",
                schema: "CSI",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Logs_CreatedAt",
                schema: "CSI",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_IsActive",
                schema: "CSI",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_LanguageCode",
                schema: "CSI",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CreatedAt",
                schema: "CSI",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_IsActive",
                schema: "CSI",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_LanguageCode",
                schema: "CSI",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_LanguagePacks_CreatedAt",
                schema: "CSI",
                table: "LanguagePacks");

            migrationBuilder.DropIndex(
                name: "IX_LanguagePacks_IsActive",
                schema: "CSI",
                table: "LanguagePacks");

            migrationBuilder.DropIndex(
                name: "IX_LanguagePacks_LanguageCode",
                schema: "CSI",
                table: "LanguagePacks");

            migrationBuilder.DropIndex(
                name: "IX_Items_CreatedAt",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_IsActive",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategoryToStaffCategory_CreatedAt",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategoryToStaffCategory_IsActive",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategoryToStaffCategory_LanguageCode",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategories_CreatedAt",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategories_IsActive",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_IncidentTypeToStaffCategories_CreatedAt",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories");

            migrationBuilder.DropIndex(
                name: "IX_IncidentTypeToStaffCategories_IsActive",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories");

            migrationBuilder.DropIndex(
                name: "IX_IncidentTypeToStaffCategories_LanguageCode",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories");

            migrationBuilder.DropIndex(
                name: "IX_IncidentTypes_CreatedAt",
                schema: "CSI",
                table: "IncidentTypes");

            migrationBuilder.DropIndex(
                name: "IX_IncidentTypes_IsActive",
                schema: "CSI",
                table: "IncidentTypes");

            migrationBuilder.DropIndex(
                name: "IX_IncidentTypes_LanguageCode",
                schema: "CSI",
                table: "IncidentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_CreatedAt",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_IsActive",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_LanguageCode",
                schema: "CSI",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Guests_CreatedAt",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_IsActive",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_LanguageCode",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_GuestNotifications_CreatedAt",
                schema: "CSI",
                table: "GuestNotifications");

            migrationBuilder.DropIndex(
                name: "IX_GuestNotifications_IsActive",
                schema: "CSI",
                table: "GuestNotifications");

            migrationBuilder.DropIndex(
                name: "IX_GuestNotifications_LanguageCode",
                schema: "CSI",
                table: "GuestNotifications");

            migrationBuilder.DropIndex(
                name: "IX_GuestLanguages_CreatedAt",
                schema: "CSI",
                table: "GuestLanguages");

            migrationBuilder.DropIndex(
                name: "IX_GuestLanguages_IsActive",
                schema: "CSI",
                table: "GuestLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CreatedAt",
                schema: "CSI",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_IsActive",
                schema: "CSI",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CreatedAt",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_IsActive",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_AudioResponses_CreatedAt",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.DropIndex(
                name: "IX_AudioResponses_IsActive",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementTypes_CreatedAt",
                schema: "CSI",
                table: "AdvertisementTypes");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementTypes_IsActive",
                schema: "CSI",
                table: "AdvertisementTypes");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_CreatedAt",
                schema: "CSI",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_IsActive",
                schema: "CSI",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "TaskLogs");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffSupports");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffSupportResponses");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffSentiments");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffNotifications");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffIncidents");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffCategories");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "StaffAboutRanOutItems");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantOrderPayments");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantItemToCarts");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantItems");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantItemCategories");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "QRCodes");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "PromoCode");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "LanguagePacks");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "IncidentTypes");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "GuestNotifications");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "CSI",
                table: "AudioResponses");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "AdvertisementTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Advertisements",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Rating",
                schema: "CSI",
                table: "Feedbacks",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_CreatedDate",
                schema: "CSI",
                table: "AudioResponses",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_EndDate",
                schema: "CSI",
                table: "Advertisements",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_StartDate",
                schema: "CSI",
                table: "Advertisements",
                column: "StartDate");
        }
    }
}
