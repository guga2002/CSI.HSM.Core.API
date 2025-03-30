using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class jhsk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_LanguageId",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                schema: "CSI",
                table: "Guests",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageCode",
                schema: "CSI",
                table: "Guests");

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "CSI",
                table: "Guests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_LanguageId",
                schema: "CSI",
                table: "Guests",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_LanguagePacks_LanguageId",
                schema: "CSI",
                table: "Guests",
                column: "LanguageId",
                principalSchema: "CSI",
                principalTable: "LanguagePacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
