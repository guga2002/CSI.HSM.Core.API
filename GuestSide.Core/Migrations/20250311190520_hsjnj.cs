using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class hsjnj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffReserveItems_Items_ItemId",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffReserveItems_Staffs_StaffId",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropIndex(
                name: "IX_StaffReserveItems_ItemId",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropIndex(
                name: "IX_StaffReserveItems_StaffId",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropColumn(
                name: "StaffId",
                schema: "CSI",
                table: "StaffReserveItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "CSI",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                schema: "CSI",
                table: "StaffReserveItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StaffId",
                schema: "CSI",
                table: "StaffReserveItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "CSI",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StaffReserveItems_ItemId",
                schema: "CSI",
                table: "StaffReserveItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffReserveItems_StaffId",
                schema: "CSI",
                table: "StaffReserveItems",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffReserveItems_Items_ItemId",
                schema: "CSI",
                table: "StaffReserveItems",
                column: "ItemId",
                principalSchema: "CSI",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffReserveItems_Staffs_StaffId",
                schema: "CSI",
                table: "StaffReserveItems",
                column: "StaffId",
                principalSchema: "CSI",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
