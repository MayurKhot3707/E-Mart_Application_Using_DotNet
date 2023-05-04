using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emartfinalproject.Migrations
{
    /// <inheritdoc />
    public partial class f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatMaster_ProductMaster_ProductMastersProductID",
                table: "CatMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDtlMaster_ConfigMaster_ConfigMastersConfigID",
                table: "ProductDtlMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDtlMaster_ProductMaster_ProductMastersProductID",
                table: "ProductDtlMaster");

            migrationBuilder.AlterColumn<string>(
                name: "ProductShortDescription",
                table: "ProductMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "ProductMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductLongDescription",
                table: "ProductMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductMastersProductID",
                table: "ProductDtlMaster",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ConfigMastersConfigID",
                table: "ProductDtlMaster",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ConfigDtl",
                table: "ProductDtlMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SubCatID",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductMastersProductID",
                table: "CatMaster",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Flag",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CatName",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CatImagPath",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CatID",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "AddToCarts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    CardHolderPrice = table.Column<double>(type: "float", nullable: false),
                    PointRedm = table.Column<int>(type: "int", nullable: false),
                    ProductMastersProductID = table.Column<int>(type: "int", nullable: true),
                    UsersUserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddToCarts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_AddToCarts_ProductMaster_ProductMastersProductID",
                        column: x => x.ProductMastersProductID,
                        principalTable: "ProductMaster",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_AddToCarts_User_UsersUserName",
                        column: x => x.UsersUserName,
                        principalTable: "User",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderTID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    CardHolderPrice = table.Column<double>(type: "float", nullable: false),
                    PointRedm = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false),
                    UsersUserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductMastersProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderTID);
                    table.ForeignKey(
                        name: "FK_Order_ProductMaster_ProductMastersProductID",
                        column: x => x.ProductMastersProductID,
                        principalTable: "ProductMaster",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Order_User_UsersUserName",
                        column: x => x.UsersUserName,
                        principalTable: "User",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTID = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersUserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrdersOrderTID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PayID);
                    table.ForeignKey(
                        name: "FK_Payment_Order_OrdersOrderTID",
                        column: x => x.OrdersOrderTID,
                        principalTable: "Order",
                        principalColumn: "OrderTID");
                    table.ForeignKey(
                        name: "FK_Payment_User_UsersUserName",
                        column: x => x.UsersUserName,
                        principalTable: "User",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddToCarts_ProductMastersProductID",
                table: "AddToCarts",
                column: "ProductMastersProductID");

            migrationBuilder.CreateIndex(
                name: "IX_AddToCarts_UsersUserName",
                table: "AddToCarts",
                column: "UsersUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductMastersProductID",
                table: "Order",
                column: "ProductMastersProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UsersUserName",
                table: "Order",
                column: "UsersUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrdersOrderTID",
                table: "Payment",
                column: "OrdersOrderTID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UsersUserName",
                table: "Payment",
                column: "UsersUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_CatMaster_ProductMaster_ProductMastersProductID",
                table: "CatMaster",
                column: "ProductMastersProductID",
                principalTable: "ProductMaster",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDtlMaster_ConfigMaster_ConfigMastersConfigID",
                table: "ProductDtlMaster",
                column: "ConfigMastersConfigID",
                principalTable: "ConfigMaster",
                principalColumn: "ConfigID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDtlMaster_ProductMaster_ProductMastersProductID",
                table: "ProductDtlMaster",
                column: "ProductMastersProductID",
                principalTable: "ProductMaster",
                principalColumn: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatMaster_ProductMaster_ProductMastersProductID",
                table: "CatMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDtlMaster_ConfigMaster_ConfigMastersConfigID",
                table: "ProductDtlMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDtlMaster_ProductMaster_ProductMastersProductID",
                table: "ProductDtlMaster");

            migrationBuilder.DropTable(
                name: "AddToCarts");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<string>(
                name: "ProductShortDescription",
                table: "ProductMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "ProductMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductLongDescription",
                table: "ProductMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductMastersProductID",
                table: "ProductDtlMaster",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConfigMastersConfigID",
                table: "ProductDtlMaster",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConfigDtl",
                table: "ProductDtlMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubCatID",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductMastersProductID",
                table: "CatMaster",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Flag",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CatName",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CatImagPath",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CatID",
                table: "CatMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CatMaster_ProductMaster_ProductMastersProductID",
                table: "CatMaster",
                column: "ProductMastersProductID",
                principalTable: "ProductMaster",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDtlMaster_ConfigMaster_ConfigMastersConfigID",
                table: "ProductDtlMaster",
                column: "ConfigMastersConfigID",
                principalTable: "ConfigMaster",
                principalColumn: "ConfigID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDtlMaster_ProductMaster_ProductMastersProductID",
                table: "ProductDtlMaster",
                column: "ProductMastersProductID",
                principalTable: "ProductMaster",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
