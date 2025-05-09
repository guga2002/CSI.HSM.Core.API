using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class addNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_IsOrderAble",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsOrderAble",
                schema: "CSI",
                table: "Items");

            migrationBuilder.AddColumn<long>(
                name: "IssueKeuwordId",
                schema: "CSI",
                table: "TaskItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemBehaviorTypeId",
                schema: "CSI",
                table: "Items",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "IssueKeywords",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueKeywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemBehaviorTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBehaviorTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_IssueKeuwordId",
                schema: "CSI",
                table: "TaskItems",
                column: "IssueKeuwordId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemBehaviorTypeId",
                schema: "CSI",
                table: "Items",
                column: "ItemBehaviorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueKeywords_CreatedAt",
                schema: "CSI",
                table: "IssueKeywords",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_IssueKeywords_IsActive",
                schema: "CSI",
                table: "IssueKeywords",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_IssueKeywords_LanguageCode",
                schema: "CSI",
                table: "IssueKeywords",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBehaviorTypes_CreatedAt",
                table: "ItemBehaviorTypes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBehaviorTypes_IsActive",
                table: "ItemBehaviorTypes",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBehaviorTypes_LanguageCode",
                table: "ItemBehaviorTypes",
                column: "LanguageCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemBehaviorTypes_ItemBehaviorTypeId",
                schema: "CSI",
                table: "Items",
                column: "ItemBehaviorTypeId",
                principalTable: "ItemBehaviorTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_IssueKeywords_IssueKeuwordId",
                schema: "CSI",
                table: "TaskItems",
                column: "IssueKeuwordId",
                principalSchema: "CSI",
                principalTable: "IssueKeywords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemBehaviorTypes_ItemBehaviorTypeId",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_IssueKeywords_IssueKeuwordId",
                schema: "CSI",
                table: "TaskItems");

            migrationBuilder.DropTable(
                name: "IssueKeywords",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "ItemBehaviorTypes");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_IssueKeuwordId",
                schema: "CSI",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemBehaviorTypeId",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IssueKeuwordId",
                schema: "CSI",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "ItemBehaviorTypeId",
                schema: "CSI",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "IsOrderAble",
                schema: "CSI",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Items_IsOrderAble",
                schema: "CSI",
                table: "Items",
                column: "IsOrderAble");
        }
    }
}
