using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class addnewtables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemReports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    reportedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ReportReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemReports_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "CSI",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemReportAttachments",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemReportId = table.Column<long>(type: "bigint", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReportAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemReportAttachments_ItemReports_ItemReportId",
                        column: x => x.ItemReportId,
                        principalTable: "ItemReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemReportAttachments_CreatedAt",
                schema: "CSI",
                table: "ItemReportAttachments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReportAttachments_IsActive",
                schema: "CSI",
                table: "ItemReportAttachments",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReportAttachments_ItemReportId",
                schema: "CSI",
                table: "ItemReportAttachments",
                column: "ItemReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReportAttachments_LanguageCode",
                schema: "CSI",
                table: "ItemReportAttachments",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReports_CreatedAt",
                table: "ItemReports",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReports_IsActive",
                table: "ItemReports",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReports_ItemId",
                table: "ItemReports",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReports_LanguageCode",
                table: "ItemReports",
                column: "LanguageCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemReportAttachments",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "ItemReports");
        }
    }
}
