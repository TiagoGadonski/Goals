using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Migrations
{
    /// <inheritdoc />
    public partial class FinancesCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaidThisMonth",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPaymentDate",
                table: "Transactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Parcelas",
                table: "FinancialGoal",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ParcelaAtual",
                table: "FinancialGoal",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<decimal>(
                name: "InstallmentValue",
                table: "FinancialGoal",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaidThisMonth",
                table: "FinancialGoal",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPaymentDate",
                table: "FinancialGoal",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaidThisMonth",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastPaymentDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "InstallmentValue",
                table: "FinancialGoal");

            migrationBuilder.DropColumn(
                name: "IsPaidThisMonth",
                table: "FinancialGoal");

            migrationBuilder.DropColumn(
                name: "LastPaymentDate",
                table: "FinancialGoal");

            migrationBuilder.AlterColumn<string>(
                name: "Parcelas",
                table: "FinancialGoal",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ParcelaAtual",
                table: "FinancialGoal",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
