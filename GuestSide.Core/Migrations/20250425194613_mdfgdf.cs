using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class mdfgdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoiceRequests",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<long>(type: "bigint", nullable: false),
                    VoiceText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceRequests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoiceRequests_CreatedAt",
                schema: "CSI",
                table: "VoiceRequests",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_VoiceRequests_IsActive",
                schema: "CSI",
                table: "VoiceRequests",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_VoiceRequests_LanguageCode",
                schema: "CSI",
                table: "VoiceRequests",
                column: "LanguageCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoiceRequests",
                schema: "CSI");
        }
    }
}
