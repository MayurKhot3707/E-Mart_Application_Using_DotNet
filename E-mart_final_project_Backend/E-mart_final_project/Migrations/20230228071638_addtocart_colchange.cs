using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emartfinalproject.Migrations
{
    /// <inheritdoc />
    public partial class addtocart_colchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "AddToCarts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "AddToCarts");
        }
    }
}
