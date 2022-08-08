using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RestrictRemoveFromDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_ShopBrands_ShopBrandId",
                table: "Shops");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_ShopBrands_ShopBrandId",
                table: "Shops",
                column: "ShopBrandId",
                principalTable: "ShopBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_ShopBrands_ShopBrandId",
                table: "Shops");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_ShopBrands_ShopBrandId",
                table: "Shops",
                column: "ShopBrandId",
                principalTable: "ShopBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
