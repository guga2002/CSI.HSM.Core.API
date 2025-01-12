using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class restaurantFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartToStaffs_Staffs_StaffId",
                schema: "CSI",
                table: "CartToStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_CartToStaffs_TaskStatus_StatusId",
                schema: "CSI",
                table: "CartToStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_CartToStaffs_Tasks_TaskId",
                schema: "CSI",
                table: "CartToStaffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartToStaffs",
                schema: "CSI",
                table: "CartToStaffs");

            migrationBuilder.RenameTable(
                name: "CartToStaffs",
                schema: "CSI",
                newName: "TaskToStaffs",
                newSchema: "CSI");

            migrationBuilder.RenameIndex(
                name: "IX_CartToStaffs_TaskId",
                schema: "CSI",
                table: "TaskToStaffs",
                newName: "IX_TaskToStaffs_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_CartToStaffs_StatusId",
                schema: "CSI",
                table: "TaskToStaffs",
                newName: "IX_TaskToStaffs_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_CartToStaffs_StaffId",
                schema: "CSI",
                table: "TaskToStaffs",
                newName: "IX_TaskToStaffs_StaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskToStaffs",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskToStaffs_Staffs_StaffId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StaffId",
                principalSchema: "CSI",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskToStaffs_TaskStatus_StatusId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StatusId",
                principalSchema: "CSI",
                principalTable: "TaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskToStaffs_Tasks_TaskId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "TaskId",
                principalSchema: "CSI",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskToStaffs_Staffs_StaffId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskToStaffs_TaskStatus_StatusId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskToStaffs_Tasks_TaskId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskToStaffs",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.RenameTable(
                name: "TaskToStaffs",
                schema: "CSI",
                newName: "CartToStaffs",
                newSchema: "CSI");

            migrationBuilder.RenameIndex(
                name: "IX_TaskToStaffs_TaskId",
                schema: "CSI",
                table: "CartToStaffs",
                newName: "IX_CartToStaffs_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskToStaffs_StatusId",
                schema: "CSI",
                table: "CartToStaffs",
                newName: "IX_CartToStaffs_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskToStaffs_StaffId",
                schema: "CSI",
                table: "CartToStaffs",
                newName: "IX_CartToStaffs_StaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartToStaffs",
                schema: "CSI",
                table: "CartToStaffs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartToStaffs_Staffs_StaffId",
                schema: "CSI",
                table: "CartToStaffs",
                column: "StaffId",
                principalSchema: "CSI",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartToStaffs_TaskStatus_StatusId",
                schema: "CSI",
                table: "CartToStaffs",
                column: "StatusId",
                principalSchema: "CSI",
                principalTable: "TaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartToStaffs_Tasks_TaskId",
                schema: "CSI",
                table: "CartToStaffs",
                column: "TaskId",
                principalSchema: "CSI",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
