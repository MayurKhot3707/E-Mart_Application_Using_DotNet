using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emartfinalproject.Migrations
{
    /// <inheritdoc />
    public partial class add_toCart_col_update_withQTY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "AddToCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "AddToCarts");
        }
    }
}
