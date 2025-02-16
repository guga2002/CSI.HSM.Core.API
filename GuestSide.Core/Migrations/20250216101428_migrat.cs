using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Core.Migrations
{
    /// <inheritdoc />
    public partial class migrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "CSI",
                table: "TaskToStaffs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "CSI",
                table: "TaskToStaffs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
