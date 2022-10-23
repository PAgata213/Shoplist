using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RefactorListOfProductsToBuy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfProductsToBuyProduct");

            migrationBuilder.CreateTable(
                name: "ProductToBuy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToBuy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductToBuy_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfProductsToBuyProductToBuy",
                columns: table => new
                {
                    ListsOfProductsToBuyId = table.Column<int>(type: "int", nullable: false),
                    ProductsToBuyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfProductsToBuyProductToBuy", x => new { x.ListsOfProductsToBuyId, x.ProductsToBuyId });
                    table.ForeignKey(
                        name: "FK_ListOfProductsToBuyProductToBuy_ListsOfProductsToBuy_ListsOfProductsToBuyId",
                        column: x => x.ListsOfProductsToBuyId,
                        principalTable: "ListsOfProductsToBuy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfProductsToBuyProductToBuy_ProductToBuy_ProductsToBuyId",
                        column: x => x.ProductsToBuyId,
                        principalTable: "ProductToBuy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfProductsToBuyProductToBuy_ProductsToBuyId",
                table: "ListOfProductsToBuyProductToBuy",
                column: "ProductsToBuyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToBuy_ProductId",
                table: "ProductToBuy",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfProductsToBuyProductToBuy");

            migrationBuilder.DropTable(
                name: "ProductToBuy");

            migrationBuilder.CreateTable(
                name: "ListOfProductsToBuyProduct",
                columns: table => new
                {
                    ListsOfProductsToBuyId = table.Column<int>(type: "int", nullable: false),
                    ProductsToBuyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfProductsToBuyProduct", x => new { x.ListsOfProductsToBuyId, x.ProductsToBuyId });
                    table.ForeignKey(
                        name: "FK_ListOfProductsToBuyProduct_ListsOfProductsToBuy_ListsOfProductsToBuyId",
                        column: x => x.ListsOfProductsToBuyId,
                        principalTable: "ListsOfProductsToBuy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfProductsToBuyProduct_Products_ProductsToBuyId",
                        column: x => x.ProductsToBuyId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfProductsToBuyProduct_ProductsToBuyId",
                table: "ListOfProductsToBuyProduct",
                column: "ProductsToBuyId");
        }
    }
}
