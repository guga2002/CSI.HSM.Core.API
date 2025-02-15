using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class addRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CSI");

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
                name: "LanguagePacks",
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
                    table.PrimaryKey("PK_LanguagePacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmergency = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantItemCategories",
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
                    table.PrimaryKey("PK_RestaurantItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaunrantCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementTypes",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisementTypes_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_AudioResponses_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    LanguagePackId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotels_LanguagePacks_LanguagePackId",
                        column: x => x.LanguagePackId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    LanguagePackId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategories_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCategories_LanguagePacks_LanguagePackId",
                        column: x => x.LanguagePackId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomCategories_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffCategories_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskStatus_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantsItems",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergens = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantItemCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    RestaurantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaunrantItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaunrantItems_RestaurantItemCategories_RestaurantItemCategoryId",
                        column: x => x.RestaurantItemCategoryId,
                        principalSchema: "CSI",
                        principalTable: "RestaurantItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaunrantItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalSchema: "CSI",
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvertisementTypeId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_AdvertisementTypes_AdvertisementTypeId",
                        column: x => x.AdvertisementTypeId,
                        principalSchema: "CSI",
                        principalTable: "AdvertisementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisements_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    HotelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "CSI",
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    LanguagePackId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemCategories_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalSchema: "CSI",
                        principalTable: "ItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_LanguagePacks_LanguagePackId",
                        column: x => x.LanguagePackId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderableItems",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    ItemCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    LanguagePackId = table.Column<long>(type: "bigint", nullable: true)
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
                name: "Rooms",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    HotelId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "CSI",
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomCategories_RoomCategoryId",
                        column: x => x.RoomCategoryId,
                        principalSchema: "CSI",
                        principalTable: "RoomCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StaffCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_StaffCategories_StaffCategoryId",
                        column: x => x.StaffCategoryId,
                        principalSchema: "CSI",
                        principalTable: "StaffCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    IsFrequentGuest = table.Column<bool>(type: "bit", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preferences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guests_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "CSI",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guests_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "CSI",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QRCodes",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QrCodeImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    GeneratedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QRCodes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "CSI",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffNotifications",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<long>(type: "bigint", nullable: false),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalSchema: "CSI",
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffNotifications_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "CSI",
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<long>(type: "bigint", nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    LanguagePackId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Guests_GuestId",
                        column: x => x.GuestId,
                        principalSchema: "CSI",
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_LanguagePacks_LanguagePackId",
                        column: x => x.LanguagePackId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GuestLanguages",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestID = table.Column<long>(type: "bigint", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestLanguages_Guests_GuestID",
                        column: x => x.GuestID,
                        principalSchema: "CSI",
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestNotifications",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<long>(type: "bigint", nullable: false),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestNotifications_Guests_GuestId",
                        column: x => x.GuestId,
                        principalSchema: "CSI",
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalSchema: "CSI",
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCarts",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<long>(type: "bigint", nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaunrantItemId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentMethodId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantCarts_Guests_GuestId",
                        column: x => x.GuestId,
                        principalSchema: "CSI",
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCarts_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "CSI",
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CartId = table.Column<long>(type: "bigint", nullable: false),
                    OrderableItemId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Carts_CartId",
                        column: x => x.CartId,
                        principalSchema: "CSI",
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_OrderableItems_OrderableItemId",
                        column: x => x.OrderableItemId,
                        principalSchema: "CSI",
                        principalTable: "OrderableItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_TaskCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "CSI",
                        principalTable: "TaskCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaunrantItemRestaurantCart",
                schema: "CSI",
                columns: table => new
                {
                    RestaunrantItemId = table.Column<long>(type: "bigint", nullable: false),
                    RestaurantCartId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaunrantItemRestaurantCart", x => new { x.RestaunrantItemId, x.RestaurantCartId });
                    table.ForeignKey(
                        name: "FK_RestaunrantItemRestaurantCart_RestaunrantItems_RestaunrantItemId",
                        column: x => x.RestaunrantItemId,
                        principalSchema: "CSI",
                        principalTable: "RestaurantsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaunrantItemRestaurantCart_RestaurantCarts_RestaurantCartId",
                        column: x => x.RestaurantCartId,
                        principalSchema: "CSI",
                        principalTable: "RestaurantCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartToStaffs",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StaffId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    TaskId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartToStaffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartToStaffs_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "CSI",
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartToStaffs_TaskStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "CSI",
                        principalTable: "TaskStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartToStaffs_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "CSI",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    TasksId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_LanguagePacks_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "CSI",
                        principalTable: "LanguagePacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalSchema: "CSI",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AdvertisementTypeId",
                schema: "CSI",
                table: "Advertisements",
                column: "AdvertisementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_LanguageId",
                schema: "CSI",
                table: "Advertisements",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementTypes_LanguageId",
                schema: "CSI",
                table: "AdvertisementTypes",
                column: "LanguageId");

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
                name: "IX_Carts_GuestId",
                schema: "CSI",
                table: "Carts",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LanguageId",
                schema: "CSI",
                table: "Carts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LanguagePackId",
                schema: "CSI",
                table: "Carts",
                column: "LanguagePackId");

            migrationBuilder.CreateIndex(
                name: "IX_CartToStaffs_StaffId",
                schema: "CSI",
                table: "CartToStaffs",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CartToStaffs_StatusId",
                schema: "CSI",
                table: "CartToStaffs",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CartToStaffs_TaskId",
                schema: "CSI",
                table: "CartToStaffs",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_LanguageId",
                schema: "CSI",
                table: "Feedbacks",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TasksId",
                schema: "CSI",
                table: "Feedbacks",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestLanguages_GuestID",
                schema: "CSI",
                table: "GuestLanguages",
                column: "GuestID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestNotifications_GuestId",
                schema: "CSI",
                table: "GuestNotifications",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestNotifications_NotificationId",
                schema: "CSI",
                table: "GuestNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_LanguageId",
                schema: "CSI",
                table: "Guests",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_RoomId",
                schema: "CSI",
                table: "Guests",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_StatusId",
                schema: "CSI",
                table: "Guests",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LanguageId",
                schema: "CSI",
                table: "Hotels",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LanguagePackId",
                schema: "CSI",
                table: "Hotels",
                column: "LanguagePackId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_LanguageId",
                schema: "CSI",
                table: "ItemCategories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_LanguagePackId",
                schema: "CSI",
                table: "ItemCategories",
                column: "LanguagePackId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCategoryId",
                schema: "CSI",
                table: "Items",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LanguageId",
                schema: "CSI",
                table: "Items",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LanguagePackId",
                schema: "CSI",
                table: "Items",
                column: "LanguagePackId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_HotelId",
                schema: "CSI",
                table: "Locations",
                column: "HotelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_LanguageId",
                schema: "CSI",
                table: "Notifications",
                column: "LanguageId");

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
                name: "IX_QRCodes_RoomId",
                schema: "CSI",
                table: "QRCodes",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaunrantItemRestaurantCart_RestaurantCartId",
                schema: "CSI",
                table: "RestaunrantItemRestaurantCart",
                column: "RestaurantCartId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaunrantItems_RestaurantId",
                schema: "CSI",
                table: "RestaurantsItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaunrantItems_RestaurantItemCategoryId",
                schema: "CSI",
                table: "RestaurantsItems",
                column: "RestaurantItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_GuestId",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_PaymentMethodId",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_LanguageId",
                schema: "CSI",
                table: "RoomCategories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                schema: "CSI",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LanguageId",
                schema: "CSI",
                table: "Rooms",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCategoryId",
                schema: "CSI",
                table: "Rooms",
                column: "RoomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCategories_LanguageId",
                schema: "CSI",
                table: "StaffCategories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffNotifications_NotificationId",
                schema: "CSI",
                table: "StaffNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffNotifications_StaffId",
                schema: "CSI",
                table: "StaffNotifications",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffCategoryId",
                schema: "CSI",
                table: "Staffs",
                column: "StaffCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_LanguageId",
                schema: "CSI",
                table: "Statuses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskCategories_LanguageId",
                schema: "CSI",
                table: "TaskCategories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CartId",
                schema: "CSI",
                table: "Tasks",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                schema: "CSI",
                table: "Tasks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LanguageId",
                schema: "CSI",
                table: "Tasks",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OrderableItemId",
                schema: "CSI",
                table: "Tasks",
                column: "OrderableItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatus_LanguageId",
                schema: "CSI",
                table: "TaskStatus",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "AudioResponses",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "CartToStaffs",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Feedbacks",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "GuestLanguages",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "GuestNotifications",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Logs",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "QRCodes",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaunrantItemRestaurantCart",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffNotifications",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "AdvertisementTypes",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "AudioResponseCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "TaskStatus",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaurantsItems",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaurantCarts",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Staffs",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Carts",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "OrderableItems",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "TaskCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaurantItemCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Restaurants",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "PaymentMethods",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Guests",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "ItemCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Hotels",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RoomCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "LanguagePacks",
                schema: "CSI");
        }
    }
}
