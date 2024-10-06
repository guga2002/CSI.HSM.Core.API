using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestSide.Core.Migrations
{
    /// <inheritdoc />
    public partial class MGRT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "QrCodeImage",
                table: "QRCodes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "QRCodes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrCodeImage",
                table: "QRCodes");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "QRCodes");
        }
    }
}
