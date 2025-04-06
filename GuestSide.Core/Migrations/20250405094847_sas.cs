using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class sas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StaffSupportResponses_TicketId",
                schema: "CSI",
                table: "StaffSupportResponses");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupportResponses_TicketId",
                schema: "CSI",
                table: "StaffSupportResponses",
                column: "TicketId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StaffSupportResponses_TicketId",
                schema: "CSI",
                table: "StaffSupportResponses");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSupportResponses_TicketId",
                schema: "CSI",
                table: "StaffSupportResponses",
                column: "TicketId");
        }
    }
}
