using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddListOfProductsToBuy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListsOfProductsToBuy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListsOfProductsToBuy", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfProductsToBuyProduct");

            migrationBuilder.DropTable(
                name: "ListsOfProductsToBuy");
        }
    }
}
