using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class fixBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskToStaffs_StaffCategories_StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropIndex(
                name: "IX_TaskToStaffs_StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropColumn(
                name: "StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StaffCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskToStaffs_StaffCategories_StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StaffCategoryId",
                principalSchema: "CSI",
                principalTable: "StaffCategories",
                principalColumn: "Id");
        }
    }
}
