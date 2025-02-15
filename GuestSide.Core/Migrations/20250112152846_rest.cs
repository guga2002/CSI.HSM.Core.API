using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class rest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCarts_PaymentMethods_PaymentMethodId",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropTable(
                name: "PaymentMethods",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaunrantItemRestaurantCart",
                schema: "CSI");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantCarts_PaymentMethodId",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.AlterColumn<long>(
                name: "RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "CSI",
                table: "RestaurantsItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvaliable",
                schema: "CSI",
                table: "RestaurantsItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "CSI",
                table: "RestaurantsItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentOptions",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_Method_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantItemToCarts",
                schema: "CSI",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantCartId = table.Column<long>(type: "bigint", nullable: false),
                    RestaunrantItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantItemToCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantItemToCarts_RestaunrantItems_RestaunrantItemId",
                        column: x => x.RestaunrantItemId,
                        principalSchema: "CSI",
                        principalTable: "RestaurantsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantItemToCarts_RestaurantCarts_RestaurantCartId",
                        column: x => x.RestaurantCartId,
                        principalSchema: "CSI",
                        principalTable: "RestaurantCarts",
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
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Time_Of_Payment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentOptionId = table.Column<long>(type: "bigint", nullable: false),
                    RestaurantCartId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "RestaunrantItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemToCarts_RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantItemToCarts",
                column: "RestaunrantItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantItemToCarts_RestaurantCartId",
                schema: "CSI",
                table: "RestaurantItemToCarts",
                column: "RestaurantCartId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCarts_RestaunrantItems_RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "RestaunrantItemId",
                principalSchema: "CSI",
                principalTable: "RestaurantsItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCarts_RestaunrantItems_RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropTable(
                name: "RestaurantItemToCarts",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "RestaurantOrderPayments",
                schema: "CSI");

            migrationBuilder.DropTable(
                name: "PaymentOptions",
                schema: "CSI");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantCarts_RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "CSI",
                table: "RestaurantsItems");

            migrationBuilder.DropColumn(
                name: "IsAvaliable",
                schema: "CSI",
                table: "RestaurantsItems");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "CSI",
                table: "RestaurantsItems");

            migrationBuilder.AlterColumn<long>(
                name: "RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaymentMethodId",
                schema: "CSI",
                table: "RestaurantCarts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_PaymentMethodId",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaunrantItemRestaurantCart_RestaurantCartId",
                schema: "CSI",
                table: "RestaunrantItemRestaurantCart",
                column: "RestaurantCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCarts_PaymentMethods_PaymentMethodId",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "PaymentMethodId",
                principalSchema: "CSI",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
