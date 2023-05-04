using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emartfinalproject.Migrations
{
    /// <inheritdoc />
    public partial class fi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigMaster",
                columns: table => new
                {
                    ConfigID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigMaster", x => x.ConfigID);
                });

            migrationBuilder.CreateTable(
                name: "ProductMaster",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductLongDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CardHolderPrice = table.Column<double>(type: "float", nullable: false),
                    PointRedm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaster", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "CatMaster",
                columns: table => new
                {
                    CatMasterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCatID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    CatImagPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductMastersProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatMaster", x => x.CatMasterID);
                    table.ForeignKey(
                        name: "FK_CatMaster_ProductMaster_ProductMastersProductID",
                        column: x => x.ProductMastersProductID,
                        principalTable: "ProductMaster",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDtlMaster",
                columns: table => new
                {
                    ProductDtlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ConfigID = table.Column<int>(type: "int", nullable: false),
                    ConfigDtl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductMastersProductID = table.Column<int>(type: "int", nullable: false),
                    ConfigMastersConfigID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDtlMaster", x => x.ProductDtlID);
                    table.ForeignKey(
                        name: "FK_ProductDtlMaster_ConfigMaster_ConfigMastersConfigID",
                        column: x => x.ConfigMastersConfigID,
                        principalTable: "ConfigMaster",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDtlMaster_ProductMaster_ProductMastersProductID",
                        column: x => x.ProductMastersProductID,
                        principalTable: "ProductMaster",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatMaster_ProductMastersProductID",
                table: "CatMaster",
                column: "ProductMastersProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDtlMaster_ConfigMastersConfigID",
                table: "ProductDtlMaster",
                column: "ConfigMastersConfigID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDtlMaster_ProductMastersProductID",
                table: "ProductDtlMaster",
                column: "ProductMastersProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatMaster");

            migrationBuilder.DropTable(
                name: "ProductDtlMaster");

            migrationBuilder.DropTable(
                name: "ConfigMaster");

            migrationBuilder.DropTable(
                name: "ProductMaster");
        }
    }
}
