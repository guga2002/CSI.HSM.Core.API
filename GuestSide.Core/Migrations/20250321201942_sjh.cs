using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class sjh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Staffs_AssignedByStaffId",
                schema: "CSI",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_AssignedByStaffId",
                schema: "CSI",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "AssignedByStaffId",
                schema: "CSI",
                table: "TaskItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AssignedByStaffId",
                schema: "CSI",
                table: "TaskItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_AssignedByStaffId",
                schema: "CSI",
                table: "TaskItems",
                column: "AssignedByStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Staffs_AssignedByStaffId",
                schema: "CSI",
                table: "TaskItems",
                column: "AssignedByStaffId",
                principalSchema: "CSI",
                principalTable: "Staffs",
                principalColumn: "Id");
        }
    }
}
