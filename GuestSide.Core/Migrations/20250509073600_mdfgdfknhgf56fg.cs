using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class mdfgdfknhgf56fg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ItemBehaviorTypes",
                newName: "ItemBehaviorTypes",
                newSchema: "CSI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ItemBehaviorTypes",
                schema: "CSI",
                newName: "ItemBehaviorTypes");
        }
    }
}
