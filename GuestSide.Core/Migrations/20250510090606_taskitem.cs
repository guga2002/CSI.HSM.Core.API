using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class taskitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReportAttachments_ItemReports_ItemReportId",
                schema: "CSI",
                table: "ItemReportAttachments");

            migrationBuilder.RenameColumn(
                name: "ItemReportId",
                schema: "CSI",
                table: "ItemReportAttachments",
                newName: "TaskItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemReportAttachments_ItemReportId",
                schema: "CSI",
                table: "ItemReportAttachments",
                newName: "IX_ItemReportAttachments_TaskItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReportAttachments_TaskItems_TaskItemId",
                schema: "CSI",
                table: "ItemReportAttachments",
                column: "TaskItemId",
                principalSchema: "CSI",
                principalTable: "TaskItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReportAttachments_TaskItems_TaskItemId",
                schema: "CSI",
                table: "ItemReportAttachments");

            migrationBuilder.RenameColumn(
                name: "TaskItemId",
                schema: "CSI",
                table: "ItemReportAttachments",
                newName: "ItemReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemReportAttachments_TaskItemId",
                schema: "CSI",
                table: "ItemReportAttachments",
                newName: "IX_ItemReportAttachments_ItemReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReportAttachments_ItemReports_ItemReportId",
                schema: "CSI",
                table: "ItemReportAttachments",
                column: "ItemReportId",
                principalSchema: "CSI",
                principalTable: "ItemReports",
                principalColumn: "Id");
        }
    }
}
