using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emartfinalproject.Migrations
{
    /// <inheritdoc />
    public partial class addtocart_col_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountPrice",
                table: "AddToCarts",
                newName: "Discount");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "AddToCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "AddToCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductShortDesc",
                table: "AddToCarts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "AddToCarts");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "AddToCarts");

            migrationBuilder.DropColumn(
                name: "ProductShortDesc",
                table: "AddToCarts");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "AddToCarts",
                newName: "DiscountPrice");
        }
    }
}
