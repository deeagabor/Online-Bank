using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank.API.Migrations
{
    /// <inheritdoc />
    public partial class AccountInfoDBAddNewAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Owner", "Sum", "UserId" },
                values: new object[] { "Pavel Carmen", 200f, 2 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Owner", "Sum", "UserId" },
                values: new object[] { 4, "Gabor Ioana", 2800f, 2 });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "Id", "AccountId", "DepositSum", "Name", "Period" },
                values: new object[,]
                {
                    { 7, 4, 100f, "Recurring Deposit", 6 },
                    { 8, 4, 12f, "Savings Deposit", 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Owner", "Sum", "UserId" },
                values: new object[] { "Gabor Andreea", 2800f, 3 });
        }
    }
}
