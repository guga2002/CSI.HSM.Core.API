using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class mikdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CSI");

            migrationBuilder.CreateTable(
                name: "AdvertisementTypes",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioResponseCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioResponseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentTypes",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguagePacks",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCountryImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoggerId = table.Column<long>(type: "bigint", nullable: true),
                    LogLevel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmergency = table.Column<bool>(type: "bit", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    PriorityLevel = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOptions",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_Method_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoCode",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsageLimit = table.Column<int>(type: "int", nullable: true),
                    UsageLimitPerGuest = table.Column<int>(type: "int", nullable: true),
                    ApplicableItemIdsSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicableGuestIdsSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSingleUse = table.Column<bool>(type: "bit", nullable: false),
                    TimesUsed = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantItemCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RestaurantCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OpeningTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ClosingTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffReserveItems",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FinalUsed = table.Column<bool>(type: "bit", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservedTill = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleasedBySystem = table.Column<bool>(type: "bit", nullable: false),
                    HandledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffReserveItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AdvertisementTypeId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PictureUrlsSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AudioResponses",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextContent = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    VoiceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AudioFilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Information = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsOrderAble = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ItemCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PicturesSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    PicturesSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilitiesSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "CSI",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantItems",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhotoUrlSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Allergens = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IngredientsSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    PreparationTimeMinutes = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestaurantItemCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    RestaurantId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantItems_RestaurantItemCategories_RestaurantItemCategoryId",
                        column: x => x.RestaurantItemCategoryId,
                        principalSchema: "CSI",
                        principalTable: "RestaurantItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalSchema: "CSI",
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidentTypeToStaffCategories",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    IncidentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypeToStaffCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentTypeToStaffCategories_IncidentTypes_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalSchema: "CSI",
                        principalTable: "IncidentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncidentTypeToStaffCategories_StaffCategories_StaffCategoryId",
                        column: x => x.StaffCategoryId,
                        principalSchema: "CSI",
                        principalTable: "StaffCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategoryToStaffCategory",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    StaffCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Staffs",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ProfilePictureUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StaffCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    SupervisorId = table.Column<long>(type: "bigint", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Staffs_Staffs_SupervisorId",
                        column: x => x.SupervisorId,
                        principalSchema: "CSI",
                        principalTable: "Staffs",
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
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MaxOccupancy = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PictureUrlsSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    HotelId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_Rooms_RoomCategories_RoomCategoryId",
                        column: x => x.RoomCategoryId,
                        principalSchema: "CSI",
                        principalTable: "RoomCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffAboutRanOutItems",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<long>(type: "bigint", nullable: false),
                    ItemIdsSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Resolved = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HandledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAboutRanOutItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffAboutRanOutItems_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "CSI",
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffIncidents",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportedByStaffId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolutionNotes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RequiresImmediateAction = table.Column<bool>(type: "bit", nullable: false),
                    IncidentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffIncidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffIncidents_IncidentTypes_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalSchema: "CSI",
                        principalTable: "IncidentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffIncidents_Staffs_ReportedByStaffId",
                        column: x => x.ReportedByStaffId,
                        principalSchema: "CSI",
                        principalTable: "Staffs",
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
                    NotificationId = table.Column<long>(type: "bigint", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsImportant = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "StaffSentiments",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<long>(type: "bigint", nullable: false),
                    SentimentScore = table.Column<double>(type: "float", nullable: false),
                    SentimentConfidence = table.Column<double>(type: "float", nullable: true),
                    SentimentLabel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KeyPhrasesSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emotion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AnalysisDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuggestedAction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffSentiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffSentiments_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "CSI",
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffSupports",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AttachmentUrlsSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffSupports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffSupports_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "CSI",
                        principalTable: "Staffs",
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
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminNotes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    IsFrequentGuest = table.Column<bool>(type: "bit", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Preferences = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
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
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QrCodeImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScannedCount = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "StaffSupportResponses",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    ResponderName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ResponseMessage = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsFromSupportTeam = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentUrlsSerialized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffSupportResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffSupportResponses_StaffSupports_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "CSI",
                        principalTable: "StaffSupports",
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
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "GuestLanguages",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestLanguages_Guests_GuestId",
                        column: x => x.GuestId,
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
                    NotificationId = table.Column<long>(type: "bigint", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsImportant = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CartId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "RestaurantItemToCarts",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantCartId = table.Column<long>(type: "bigint", nullable: false),
                    RestaurantItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsOrdered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantItemToCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantItemToCarts_RestaurantCarts_RestaurantCartId",
                        column: x => x.RestaurantCartId,
                        principalSchema: "CSI",
                        principalTable: "RestaurantCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantItemToCarts_RestaurantItems_RestaurantItemId",
                        column: x => x.RestaurantItemId,
                        principalSchema: "CSI",
                        principalTable: "RestaurantItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantOrderPayments",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Time_Of_Payment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentOptionId = table.Column<long>(type: "bigint", nullable: false),
                    RestaurantCartId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IsRefunded = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantOrderPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantOrderPayments_PaymentOptions_PaymentOptionId",
                        column: x => x.PaymentOptionId,
                        principalSchema: "CSI",
                        principalTable: "PaymentOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantOrderPayments_RestaurantCarts_RestaurantCartId",
                        column: x => x.RestaurantCartId,
                        principalSchema: "CSI",
                        principalTable: "RestaurantCarts",
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
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WhatWillRobotSay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TaskId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "CSI",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TaskLogs",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskLogs_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "CSI",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskToStaffs",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    TaskId = table.Column<long>(type: "bigint", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AssignedBy = table.Column<long>(type: "bigint", nullable: true),
                    StaffCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskToStaffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskToStaffs_StaffCategories_StaffCategoryId",
                        column: x => x.StaffCategoryId,
                        principalSchema: "CSI",
                        principalTable: "StaffCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskToStaffs_Staffs_AssignedBy",
                        column: x => x.AssignedBy,
                        principalSchema: "CSI",
                        principalTable: "Staffs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskToStaffs_TaskStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "CSI",
                        principalTable: "TaskStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskToStaffs_Tasks_TaskId",
                        column: x => x.TaskId,
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
                name: "IX_Advertisements_EndDate",
                schema: "CSI",
                table: "Advertisements",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_LanguageCode",
                schema: "CSI",
                table: "Advertisements",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_StartDate",
                schema: "CSI",
                table: "Advertisements",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementTypes_LanguageCode",
                schema: "CSI",
                table: "AdvertisementTypes",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementTypes_Name",
                schema: "CSI",
                table: "AdvertisementTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponseCategories_CategoryName",
                schema: "CSI",
                table: "AudioResponseCategories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_CategoryId",
                schema: "CSI",
                table: "AudioResponses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_CreatedDate",
                schema: "CSI",
                table: "AudioResponses",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_LanguageCode",
                schema: "CSI",
                table: "AudioResponses",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_AudioResponses_VoiceType",
                schema: "CSI",
                table: "AudioResponses",
                column: "VoiceType");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_GuestId",
                schema: "CSI",
                table: "Carts",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IsComplete",
                schema: "CSI",
                table: "Carts",
                column: "IsComplete");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LanguageCode",
                schema: "CSI",
                table: "Carts",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CorrelationId",
                schema: "CSI",
                table: "Feedbacks",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_LanguageCode",
                schema: "CSI",
                table: "Feedbacks",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Rating",
                schema: "CSI",
                table: "Feedbacks",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TaskId",
                schema: "CSI",
                table: "Feedbacks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestLanguages_GuestId",
                schema: "CSI",
                table: "GuestLanguages",
                column: "GuestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestLanguages_LanguageCode",
                schema: "CSI",
                table: "GuestLanguages",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_GuestNotifications_GuestId",
                schema: "CSI",
                table: "GuestNotifications",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestNotifications_IsRead",
                schema: "CSI",
                table: "GuestNotifications",
                column: "IsRead");

            migrationBuilder.CreateIndex(
                name: "IX_GuestNotifications_NotificationId",
                schema: "CSI",
                table: "GuestNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestNotifications_SentTime",
                schema: "CSI",
                table: "GuestNotifications",
                column: "SentTime");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_CheckInDate",
                schema: "CSI",
                table: "Guests",
                column: "CheckInDate");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_CheckOutDate",
                schema: "CSI",
                table: "Guests",
                column: "CheckOutDate");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_Email",
                schema: "CSI",
                table: "Guests",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_PhoneNumber",
                schema: "CSI",
                table: "Guests",
                column: "PhoneNumber");

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
                name: "IX_Hotels_LocationId",
                schema: "CSI",
                table: "Hotels",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypeToStaffCategories_IncidentTypeId",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypeToStaffCategories_StaffCategoryId",
                schema: "CSI",
                table: "IncidentTypeToStaffCategories",
                column: "StaffCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_CategoryName",
                schema: "CSI",
                table: "ItemCategories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_LanguageCode",
                schema: "CSI",
                table: "ItemCategories",
                column: "LanguageCode");

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
                name: "IX_Items_IsOrderAble",
                schema: "CSI",
                table: "Items",
                column: "IsOrderAble");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCategoryId",
                schema: "CSI",
                table: "Items",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LanguageCode",
                schema: "CSI",
                table: "Items",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePacks_Code",
                schema: "CSI",
                table: "LanguagePacks",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePacks_Name",
                schema: "CSI",
                table: "LanguagePacks",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Latitude_Longitude",
                schema: "CSI",
                table: "Locations",
                columns: new[] { "Latitude", "Longitude" });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CorrelationId",
                schema: "CSI",
                table: "Logs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_IsEmergency",
                schema: "CSI",
                table: "Logs",
                column: "IsEmergency");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LoggerId",
                schema: "CSI",
                table: "Logs",
                column: "LoggerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LogLevel",
                schema: "CSI",
                table: "Logs",
                column: "LogLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IsSent",
                schema: "CSI",
                table: "Notifications",
                column: "IsSent");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_LanguageCode",
                schema: "CSI",
                table: "Notifications",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationDate",
                schema: "CSI",
                table: "Notifications",
                column: "NotificationDate");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_CreatedDate",
                schema: "CSI",
                table: "PaymentOptions",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_LanguageCode",
                schema: "CSI",
                table: "PaymentOptions",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_Payment_Method_Name",
                schema: "CSI",
                table: "PaymentOptions",
                column: "Payment_Method_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QRCodes_Code",
                schema: "CSI",
                table: "QRCodes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QRCodes_RoomId",
                schema: "CSI",
                table: "QRCodes",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_CreatedAt",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_GuestId",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_IsPaid",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "IsPaid");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemCategories_CategoryName",
                schema: "CSI",
                table: "RestaurantItemCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemCategories_CreatedAt",
                schema: "CSI",
                table: "RestaurantItemCategories",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemCategories_IsActive",
                schema: "CSI",
                table: "RestaurantItemCategories",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItems_IsAvailable",
                schema: "CSI",
                table: "RestaurantItems",
                column: "IsAvailable");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItems_Price",
                schema: "CSI",
                table: "RestaurantItems",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItems_RestaurantId",
                schema: "CSI",
                table: "RestaurantItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItems_RestaurantItemCategoryId",
                schema: "CSI",
                table: "RestaurantItems",
                column: "RestaurantItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemToCarts_CreatedAt",
                schema: "CSI",
                table: "RestaurantItemToCarts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemToCarts_RestaurantCartId",
                schema: "CSI",
                table: "RestaurantItemToCarts",
                column: "RestaurantCartId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemToCarts_RestaurantItemId",
                schema: "CSI",
                table: "RestaurantItemToCarts",
                column: "RestaurantItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrderPayments_PaymentOptionId",
                schema: "CSI",
                table: "RestaurantOrderPayments",
                column: "PaymentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrderPayments_RestaurantCartId",
                schema: "CSI",
                table: "RestaurantOrderPayments",
                column: "RestaurantCartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrderPayments_Time_Of_Payment",
                schema: "CSI",
                table: "RestaurantOrderPayments",
                column: "Time_Of_Payment");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CreatedAt",
                schema: "CSI",
                table: "Restaurants",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_IsActive",
                schema: "CSI",
                table: "Restaurants",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_Name",
                schema: "CSI",
                table: "Restaurants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RestaurantCategory",
                schema: "CSI",
                table: "Restaurants",
                column: "RestaurantCategory");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_CreatedAt",
                schema: "CSI",
                table: "RoomCategories",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_IsActive",
                schema: "CSI",
                table: "RoomCategories",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_LanguageCode",
                schema: "CSI",
                table: "RoomCategories",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_Name",
                schema: "CSI",
                table: "RoomCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CreatedAt",
                schema: "CSI",
                table: "Rooms",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Floor",
                schema: "CSI",
                table: "Rooms",
                column: "Floor");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                schema: "CSI",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IsAvailable",
                schema: "CSI",
                table: "Rooms",
                column: "IsAvailable");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCategoryId",
                schema: "CSI",
                table: "Rooms",
                column: "RoomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomNumber",
                schema: "CSI",
                table: "Rooms",
                column: "RoomNumber");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAboutRanOutItems_Priority",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                column: "Priority");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAboutRanOutItems_Resolved",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                column: "Resolved");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAboutRanOutItems_StaffId",
                schema: "CSI",
                table: "StaffAboutRanOutItems",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCategories_CategoryName",
                schema: "CSI",
                table: "StaffCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffCategories_CreatedAt",
                schema: "CSI",
                table: "StaffCategories",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCategories_IsActive",
                schema: "CSI",
                table: "StaffCategories",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_StaffIncidents_IncidentTypeId",
                schema: "CSI",
                table: "StaffIncidents",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffIncidents_ReportedByStaffId",
                schema: "CSI",
                table: "StaffIncidents",
                column: "ReportedByStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffIncidents_RequiresImmediateAction",
                schema: "CSI",
                table: "StaffIncidents",
                column: "RequiresImmediateAction");

            migrationBuilder.CreateIndex(
                name: "IX_StaffIncidents_Severity",
                schema: "CSI",
                table: "StaffIncidents",
                column: "Severity");

            migrationBuilder.CreateIndex(
                name: "IX_StaffIncidents_Status",
                schema: "CSI",
                table: "StaffIncidents",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_StaffNotifications_IsRead",
                schema: "CSI",
                table: "StaffNotifications",
                column: "IsRead");

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
                name: "IX_StaffReserveItems_FinalUsed",
                schema: "CSI",
                table: "StaffReserveItems",
                column: "FinalUsed");

            migrationBuilder.CreateIndex(
                name: "IX_StaffReserveItems_ReservedTill",
                schema: "CSI",
                table: "StaffReserveItems",
                column: "ReservedTill");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Email",
                schema: "CSI",
                table: "Staffs",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_HireDate",
                schema: "CSI",
                table: "Staffs",
                column: "HireDate");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_IsActive",
                schema: "CSI",
                table: "Staffs",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_PhoneNumber",
                schema: "CSI",
                table: "Staffs",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Position",
                schema: "CSI",
                table: "Staffs",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffCategoryId",
                schema: "CSI",
                table: "Staffs",
                column: "StaffCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_SupervisorId",
                schema: "CSI",
                table: "Staffs",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSentiments_AnalysisDate",
                schema: "CSI",
                table: "StaffSentiments",
                column: "AnalysisDate");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSentiments_Emotion",
                schema: "CSI",
                table: "StaffSentiments",
                column: "Emotion");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSentiments_SentimentLabel",
                schema: "CSI",
                table: "StaffSentiments",
                column: "SentimentLabel");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSentiments_SentimentScore",
                schema: "CSI",
                table: "StaffSentiments",
                column: "SentimentScore");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSentiments_StaffId",
                schema: "CSI",
                table: "StaffSentiments",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupportResponses_IsFromSupportTeam",
                schema: "CSI",
                table: "StaffSupportResponses",
                column: "IsFromSupportTeam");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupportResponses_TicketId",
                schema: "CSI",
                table: "StaffSupportResponses",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupports_Priority",
                schema: "CSI",
                table: "StaffSupports",
                column: "Priority");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupports_StaffId",
                schema: "CSI",
                table: "StaffSupports",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupports_Status",
                schema: "CSI",
                table: "StaffSupports",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_LanguageCode",
                schema: "CSI",
                table: "Statuses",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_StatusName",
                schema: "CSI",
                table: "Statuses",
                column: "StatusName");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_IsCompleted",
                schema: "CSI",
                table: "TaskItems",
                column: "IsCompleted");

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

            migrationBuilder.CreateIndex(
                name: "IX_TaskLogs_TaskId",
                schema: "CSI",
                table: "TaskLogs",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CartId",
                schema: "CSI",
                table: "Tasks",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DueDate",
                schema: "CSI",
                table: "Tasks",
                column: "DueDate");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_IsCompleted",
                schema: "CSI",
                table: "Tasks",
                column: "IsCompleted");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LanguageCode",
                schema: "CSI",
                table: "Tasks",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatus_CreatedAt",
                schema: "CSI",
                table: "TaskStatus",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatus_IsActive",
                schema: "CSI",
                table: "TaskStatus",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatus_LanguageCode",
                schema: "CSI",
                table: "TaskStatus",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatus_NameOfStatus",
                schema: "CSI",
                table: "TaskStatus",
                column: "NameOfStatus",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_AssignedBy",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "AssignedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_EndDate",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_StaffCategoryId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StaffCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_StartDate",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_StatusId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskToStaffs_TaskId",
                schema: "CSI",
                table: "TaskToStaffs",
                column: "TaskId",
                unique: true);
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
                name: "Feedbacks",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "GuestLanguages",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "GuestNotifications",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "IncidentTypeToStaffCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "ItemCategoryToStaffCategory",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "LanguagePacks",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Logs",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "PromoCode",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "QRCodes",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaurantItemToCarts",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaurantOrderPayments",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffAboutRanOutItems",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffIncidents",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffNotifications",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffReserveItems",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffSentiments",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffSupportResponses",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "TaskItems",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "TaskLogs",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "TaskToStaffs",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "AdvertisementTypes",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "AudioResponseCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaurantItems",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "PaymentOptions",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaurantCarts",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "IncidentTypes",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffSupports",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "TaskStatus",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaurantItemCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Restaurants",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Staffs",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "ItemCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Carts",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "StaffCategories",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "Guests",
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
                name: "Locations",
                schema: "CSI");
        }
    }
}
