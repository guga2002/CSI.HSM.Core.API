using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class migrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffAboutRanOutItems_Staffs_StaffId",
                schema: "CSI",
                table: "StaffAboutRanOutItems");

            migrationBuilder.AlterColumn<long>(
                name: "StaffId",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "CSI",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffAboutRanOutItems_Staffs_StaffId",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                column: "StaffId",
                principalSchema: "CSI",
                principalTable: "Staffs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffAboutRanOutItems_Staffs_StaffId",
                schema: "CSI",
                table: "StaffAboutRanOutItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "CSI",
                table: "Items");

            migrationBuilder.AlterColumn<long>(
                name: "StaffId",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffAboutRanOutItems_Staffs_StaffId",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                column: "StaffId",
                principalSchema: "CSI",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
