using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class addScheduledDeliverytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduledDeliveries",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskItemId = table.Column<long>(type: "bigint", nullable: false),
                    ScheduledDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledDeliveries_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalSchema: "CSI",
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledDeliveries_CreatedAt",
                schema: "CSI",
                table: "ScheduledDeliveries",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledDeliveries_IsActive",
                schema: "CSI",
                table: "ScheduledDeliveries",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledDeliveries_LanguageCode",
                schema: "CSI",
                table: "ScheduledDeliveries",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledDeliveries_TaskItemId",
                schema: "CSI",
                table: "ScheduledDeliveries",
                column: "TaskItemId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledDeliveries",
                schema: "CSI");
        }
    }
}
