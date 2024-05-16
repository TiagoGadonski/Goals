using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Migrations
{
    /// <inheritdoc />
    public partial class Corrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Wish",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Wish",
                newName: "CreationDate");
        }
    }
}
