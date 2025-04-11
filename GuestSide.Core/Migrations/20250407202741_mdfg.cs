using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class mdfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBeenFinalized",
                schema: "CSI",
                table: "Guests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DailyStatistics",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalTasksCreated = table.Column<int>(type: "int", nullable: false),
                    TasksCompleted = table.Column<int>(type: "int", nullable: false),
                    TasksOverdue = table.Column<int>(type: "int", nullable: false),
                    TotalFeedbacks = table.Column<int>(type: "int", nullable: false),
                    PositiveFeedbacks = table.Column<int>(type: "int", nullable: false),
                    NegativeFeedbacks = table.Column<int>(type: "int", nullable: false),
                    SupportRequestsOpened = table.Column<int>(type: "int", nullable: false),
                    SupportRequestsResolved = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyStatistics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyStatistics_CreatedAt",
                schema: "CSI",
                table: "DailyStatistics",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_DailyStatistics_IsActive",
                schema: "CSI",
                table: "DailyStatistics",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_DailyStatistics_LanguageCode",
                schema: "CSI",
                table: "DailyStatistics",
                column: "LanguageCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyStatistics",
                schema: "CSI");

            migrationBuilder.DropColumn(
                name: "HasBeenFinalized",
                schema: "CSI",
                table: "Guests");
        }
    }
}
