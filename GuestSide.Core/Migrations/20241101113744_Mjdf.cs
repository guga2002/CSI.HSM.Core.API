using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestSide.Core.Migrations
{
    /// <inheritdoc />
    public partial class Mjdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CSI");

            migrationBuilder.RenameTable(
                name: "TaskStatus",
                newName: "TaskStatus",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Tasks",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "TaskCategories",
                newName: "TaskCategories",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "Staffs",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "StaffNotifications",
                newName: "StaffNotifications",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "StaffCategories",
                newName: "StaffCategories",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Rooms",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "RoomCategories",
                newName: "RoomCategories",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "QRCodes",
                newName: "QRCodes",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notifications",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "Logs",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Items",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "ItemCategories",
                newName: "ItemCategories",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "Guests",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "GuestNotifications",
                newName: "GuestNotifications",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "Feedbacks",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "CartToStaffs",
                newName: "CartToStaffs",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Carts",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "AdvertisementTypes",
                newName: "AdvertisementTypes",
                newSchema: "CSI");

            migrationBuilder.RenameTable(
                name: "Advertisements",
                newName: "Advertisements",
                newSchema: "CSI");

            migrationBuilder.CreateTable(
                name: "AudioResponseCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioResponseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseDictionaries",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeorgianText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDictionaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioResponses",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    VoiceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioResponses_AudioResponseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "CSI",
                        principalTable: "AudioResponseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioResponses_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationDictionaries",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    TranslatedText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseDictionaryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationDictionaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationDictionaries_BaseDictionaries_BaseDictionaryId",
                        column: x => x.BaseDictionaryId,
                        principalSchema: "CSI",
                        principalTable: "BaseDictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslationDictionaries_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_CategoryId",
                schema: "CSI",
                table: "AudioResponses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_LanguageId",
                schema: "CSI",
                table: "AudioResponses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationDictionaries_BaseDictionaryId",
                schema: "CSI",
                table: "TranslationDictionaries",
                column: "BaseDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationDictionaries_LanguageId",
                schema: "CSI",
                table: "TranslationDictionaries",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioResponses",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "TranslationDictionaries",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "AudioResponseCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "BaseDictionaries",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "CSI");

            migrationBuilder.RenameTable(
                name: "TaskStatus",
                schema: "CSI",
                newName: "TaskStatus");

            migrationBuilder.RenameTable(
                name: "Tasks",
                schema: "CSI",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "TaskCategories",
                schema: "CSI",
                newName: "TaskCategories");

            migrationBuilder.RenameTable(
                name: "Staffs",
                schema: "CSI",
                newName: "Staffs");

            migrationBuilder.RenameTable(
                name: "StaffNotifications",
                schema: "CSI",
                newName: "StaffNotifications");

            migrationBuilder.RenameTable(
                name: "StaffCategories",
                schema: "CSI",
                newName: "StaffCategories");

            migrationBuilder.RenameTable(
                name: "Rooms",
                schema: "CSI",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "RoomCategories",
                schema: "CSI",
                newName: "RoomCategories");

            migrationBuilder.RenameTable(
                name: "QRCodes",
                schema: "CSI",
                newName: "QRCodes");

            migrationBuilder.RenameTable(
                name: "Notifications",
                schema: "CSI",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "Logs",
                schema: "CSI",
                newName: "Logs");

            migrationBuilder.RenameTable(
                name: "Items",
                schema: "CSI",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "ItemCategories",
                schema: "CSI",
                newName: "ItemCategories");

            migrationBuilder.RenameTable(
                name: "Guests",
                schema: "CSI",
                newName: "Guests");

            migrationBuilder.RenameTable(
                name: "GuestNotifications",
                schema: "CSI",
                newName: "GuestNotifications");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                schema: "CSI",
                newName: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "CartToStaffs",
                schema: "CSI",
                newName: "CartToStaffs");

            migrationBuilder.RenameTable(
                name: "Carts",
                schema: "CSI",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "AdvertisementTypes",
                schema: "CSI",
                newName: "AdvertisementTypes");

            migrationBuilder.RenameTable(
                name: "Advertisements",
                schema: "CSI",
                newName: "Advertisements");
        }
    }
}
