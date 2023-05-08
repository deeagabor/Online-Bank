using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.API.Migrations
{
    /// <inheritdoc />
    public partial class AccountInfoDBNewEditDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Username",
                value: "pavelcarmen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Username",
                value: "pavelcarme");
        }
    }
}
