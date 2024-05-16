using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Migrations
{
    /// <inheritdoc />
    public partial class DeleteWish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Wish");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
