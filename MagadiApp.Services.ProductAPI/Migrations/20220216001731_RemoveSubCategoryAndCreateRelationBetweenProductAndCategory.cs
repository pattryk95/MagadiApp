using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagadiApp.Services.ProductAPI.Migrations
{
    public partial class RemoveSubCategoryAndCreateRelationBetweenProductAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Subcategory_SubcategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.RenameColumn(
                name: "SubcategoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId1",
                table: "Categories",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryId1",
                table: "Categories",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryId1",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "SubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_SubcategoryId");

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    SubcategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.SubcategoryId);
                    table.ForeignKey(
                        name: "FK_Subcategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_CategoryId",
                table: "Subcategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Subcategory_SubcategoryId",
                table: "Products",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "SubcategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
