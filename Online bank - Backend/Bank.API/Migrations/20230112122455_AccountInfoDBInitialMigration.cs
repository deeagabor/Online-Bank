using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank.API.Migrations
{
    /// <inheritdoc />
    public partial class AccountInfoDBInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sum = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    DepositSum = table.Column<float>(type: "real", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposits_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Owner", "Sum" },
                values: new object[,]
                {
                    { 1, "Gabor Andreea", 2500f },
                    { 2, "Pavel Carmen", 3200f },
                    { 3, "Wolf Lorena", 2800f }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "Id", "AccountId", "DepositSum", "Name", "Period" },
                values: new object[,]
                {
                    { 1, 1, 2000f, "Savings Deposit", 1 },
                    { 2, 1, 500f, "Fixed Deposit", 12 },
                    { 3, 2, 2200f, "Fixed Deposit", 6 },
                    { 4, 2, 1000f, "Recurring Deposit", 1 },
                    { 5, 3, 1200f, "Savings Deposit", 12 },
                    { 6, 3, 1600f, "Current Deposit", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_AccountId",
                table: "Deposits",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
