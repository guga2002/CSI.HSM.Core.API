using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class mighrcddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LanguagePacks_Code",
                schema: "CSI",
                table: "LanguagePacks");

            migrationBuilder.DropIndex(
                name: "IX_LanguagePacks_Name",
                schema: "CSI",
                table: "LanguagePacks");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LanguagePacks_Code",
                schema: "CSI",
                table: "LanguagePacks");

            migrationBuilder.DropIndex(
                name: "IX_LanguagePacks_Name",
                schema: "CSI",
                table: "LanguagePacks");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePacks_Code",
                schema: "CSI",
                table: "LanguagePacks",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePacks_Name",
                schema: "CSI",
                table: "LanguagePacks",
                column: "Name",
                unique: true);
        }
    }
}
