using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class mihdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "TaskToStaffs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "TaskStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "TaskCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Staffs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "StaffNotifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "StaffCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "RoomCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "RestaurantOrderPayments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "RestaurantItemToCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "RestaurantItemCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "RestaurantCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "RestaunrantItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "QRCodes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "OrderableItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Logs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Locations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "ItemCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Guests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "GuestNotifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "GuestLanguages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Feedbacks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "CSI",
                table: "AdvertisementTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "TaskStatus");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "TaskCategories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "StaffNotifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "StaffCategories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "RoomCategories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "RestaurantOrderPayments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "RestaurantItemToCarts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "RestaurantItemCategories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "RestaunrantItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "QRCodes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "OrderableItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "GuestNotifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "GuestLanguages");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "CSI",
                table: "AdvertisementTypes");
        }
    }
}
