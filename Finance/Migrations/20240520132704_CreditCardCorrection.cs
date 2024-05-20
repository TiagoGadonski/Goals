using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Migrations
{
    /// <inheritdoc />
    public partial class CreditCardCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "FinancialGoal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryFinances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFinances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    Installments = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentInstallment = table.Column<int>(type: "INTEGER", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardExpenses_CategoryFinances_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryFinances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialGoal_CategoryId",
                table: "FinancialGoal",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardExpenses_CategoryId",
                table: "CreditCardExpenses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialGoal_CategoryFinances_CategoryId",
                table: "FinancialGoal",
                column: "CategoryId",
                principalTable: "CategoryFinances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CategoryFinances_CategoryId",
                table: "Transactions",
                column: "CategoryId",
                principalTable: "CategoryFinances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialGoal_CategoryFinances_CategoryId",
                table: "FinancialGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CategoryFinances_CategoryId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "CreditCardExpenses");

            migrationBuilder.DropTable(
                name: "CategoryFinances");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_FinancialGoal_CategoryId",
                table: "FinancialGoal");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FinancialGoal");
        }
    }
}
