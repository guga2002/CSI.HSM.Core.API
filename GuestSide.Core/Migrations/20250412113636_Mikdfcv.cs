using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Core.Migrations
{
    /// <inheritdoc />
    public partial class Mikdfcv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnDuty",
                schema: "CSI",
                table: "Staffs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCheckedLoginTime",
                schema: "CSI",
                table: "Staffs",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnDuty",
                schema: "CSI",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "LastCheckedLoginTime",
                schema: "CSI",
                table: "Staffs");
        }
    }
}
