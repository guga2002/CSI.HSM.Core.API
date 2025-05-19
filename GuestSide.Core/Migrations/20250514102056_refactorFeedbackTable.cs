using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class refactorFeedbackTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GuestId",
                schema: "CSI",
                table: "Feedbacks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuestId",
                schema: "CSI",
                table: "Feedbacks");
        }
    }
}
