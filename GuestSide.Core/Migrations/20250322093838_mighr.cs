using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class mighr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskToStaffs_Staffs_StaffId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropIndex(
                name: "IX_TaskToStaffs_StaffId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropColumn(
                name: "StaffId",
                schema: "CSI",
                table: "TaskToStaffs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StaffId",
                schema: "CSI",
                table: "TaskToStaffs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_StaffId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskToStaffs_Staffs_StaffId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StaffId",
                principalSchema: "CSI",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
