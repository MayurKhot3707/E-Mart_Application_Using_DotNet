using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emartfinalproject.Migrations
{
    /// <inheritdoc />
    public partial class database_col_update_productmaster_addtocart_order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "AddToCarts");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "AddToCarts",
                newName: "DiscountPrice");

            migrationBuilder.AlterColumn<long>(
                name: "MobileNumber",
                table: "User",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CardHolder",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "ProductMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "ProductMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddToCartsCartID",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddToCartsCartID",
                table: "Order",
                column: "AddToCartsCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AddToCarts_AddToCartsCartID",
                table: "Order",
                column: "AddToCartsCartID",
                principalTable: "AddToCarts",
                principalColumn: "CartID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AddToCarts_AddToCartsCartID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_AddToCartsCartID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CardHolder",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "ProductMaster");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "ProductMaster");

            migrationBuilder.DropColumn(
                name: "AddToCartsCartID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "DiscountPrice",
                table: "AddToCarts",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<float>(
                name: "Discount",
                table: "AddToCarts",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
