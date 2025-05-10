using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class refactorTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Staffs_StaffId",
                schema: "CSI",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_StaffId",
                schema: "CSI",
                table: "Comments");

            migrationBuilder.AddColumn<long>(
                name: "TakenByStaffId",
                schema: "CSI",
                table: "StaffIncidents",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StaffId",
                schema: "CSI",
                table: "Comments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "GuestId",
                schema: "CSI",
                table: "Comments",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TakenByStaffId",
                schema: "CSI",
                table: "StaffIncidents");

            migrationBuilder.DropColumn(
                name: "GuestId",
                schema: "CSI",
                table: "Comments");

            migrationBuilder.AlterColumn<long>(
                name: "StaffId",
                schema: "CSI",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StaffId",
                schema: "CSI",
                table: "Comments",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Staffs_StaffId",
                schema: "CSI",
                table: "Comments",
                column: "StaffId",
                principalSchema: "CSI",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
