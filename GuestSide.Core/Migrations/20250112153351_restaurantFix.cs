using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class restaurantFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantCarts_RestaunrantItems_RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantCarts_RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts");

            migrationBuilder.DropColumn(
                name: "RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCarts_RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "RestaunrantItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantCarts_RestaunrantItems_RestaunrantItemId",
                schema: "CSI",
                table: "RestaurantCarts",
                column: "RestaunrantItemId",
                principalSchema: "CSI",
                principalTable: "RestaunrantItems",
                principalColumn: "Id");
        }
    }
}
