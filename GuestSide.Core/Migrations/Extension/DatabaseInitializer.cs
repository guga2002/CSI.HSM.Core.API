
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestSide.Core.Migrations.Extension
{
    public static class DatabaseInitializer
    {
        public static void CreateStoredProcedures(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
           Create procedure SelectAllCarts
           as 
           begin
           select * from dbo.Carts
           end"
            );
        }
    }

}
