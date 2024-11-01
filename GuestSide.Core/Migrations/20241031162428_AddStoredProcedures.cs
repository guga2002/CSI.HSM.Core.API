using GuestSide.Core.Migrations.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestSide.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateStoredProcedures();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS SelectAllCarts");
        }
    }
}
