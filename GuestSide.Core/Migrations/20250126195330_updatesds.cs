using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class updatesds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_OrderableItems_OrderableItemId",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskCategories_CategoryId",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "OrderableItems",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "TaskCategories",
                schema: "CSI");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CategoryId",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_OrderableItemId",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "OrderableItemId",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.AddColumn<long>(
                name: "StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                schema: "CSI",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "CSI",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOrderable",
                schema: "CSI",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "CSI",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemCategoryToStaffCategory",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    StaffCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategoryToStaffCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategoryToStaffCategory_ItemCategories_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalSchema: "CSI",
                        principalTable: "ItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCategoryToStaffCategory_StaffCategories_StaffCategoryId",
                        column: x => x.StaffCategoryId,
                        principalSchema: "CSI",
                        principalTable: "StaffCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "CSI",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItems_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "CSI",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StaffCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategoryToStaffCategory_ItemCategoryId",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory",
                column: "ItemCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategoryToStaffCategory_StaffCategoryId",
                schema: "CSI",
                table: "ItemCategoryToStaffCategory",
                column: "StaffCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_ItemId",
                schema: "CSI",
                table: "TaskItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_TaskId",
                schema: "CSI",
                table: "TaskItems",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskToStaffs_StaffCategories_StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StaffCategoryId",
                principalSchema: "CSI",
                principalTable: "StaffCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskToStaffs_StaffCategories_StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropTable(
                name: "ItemCategoryToStaffCategory",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "TaskItems",
                schema: "CSI");

            migrationBuilder.DropIndex(
                name: "IX_TaskToStaffs_StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropColumn(
                name: "StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs");

            migrationBuilder.DropColumn(
                name: "Note",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "CSI",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsOrderable",
                schema: "CSI",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "CSI",
                table: "Items");

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                schema: "CSI",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrderableItemId",
                schema: "CSI",
                table: "Tasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderableItems",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LanguagePackId = table.Column<long>(type: "bigint", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderableItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderableItems_ItemCategories_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalSchema: "CSI",
                        principalTable: "ItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderableItems_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderableItems_LanguagePacks_LanguagePackId",
                        column: x => x.LanguagePackId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskCategories_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                schema: "CSI",
                table: "Tasks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OrderableItemId",
                schema: "CSI",
                table: "Tasks",
                column: "OrderableItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderableItems_ItemCategoryId",
                schema: "CSI",
                table: "OrderableItems",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderableItems_LanguageId",
                schema: "CSI",
                table: "OrderableItems",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderableItems_LanguagePackId",
                schema: "CSI",
                table: "OrderableItems",
                column: "LanguagePackId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskCategories_LanguageId",
                schema: "CSI",
                table: "TaskCategories",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_OrderableItems_OrderableItemId",
                schema: "CSI",
                table: "Tasks",
                column: "OrderableItemId",
                principalSchema: "CSI",
                principalTable: "OrderableItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskCategories_CategoryId",
                schema: "CSI",
                table: "Tasks",
                column: "CategoryId",
                principalSchema: "CSI",
                principalTable: "TaskCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
