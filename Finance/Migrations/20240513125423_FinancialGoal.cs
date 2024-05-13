using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Migrations
{
    /// <inheritdoc />
    public partial class FinancialGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Check",
                table: "FinancialGoal",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ParcelaAtual",
                table: "FinancialGoal",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parcelas",
                table: "FinancialGoal",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Check",
                table: "FinancialGoal");

            migrationBuilder.DropColumn(
                name: "ParcelaAtual",
                table: "FinancialGoal");

            migrationBuilder.DropColumn(
                name: "Parcelas",
                table: "FinancialGoal");
        }
    }
}
