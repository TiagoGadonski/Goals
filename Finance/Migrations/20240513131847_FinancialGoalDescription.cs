using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Migrations
{
    /// <inheritdoc />
    public partial class FinancialGoalDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FinancialGoal",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FinancialGoal");
        }
    }
}
