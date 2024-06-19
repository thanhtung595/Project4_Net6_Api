using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lib_DatabaseEntity.Migrations
{
    /// <inheritdoc />
    public partial class add_tb_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    describe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    priceSale = table.Column<float>(type: "real", nullable: false),
                    isSale = table.Column<bool>(type: "bit", nullable: false),
                    countProduct = table.Column<int>(type: "int", nullable: false),
                    isDelete = table.Column<int>(type: "int", nullable: false),
                    idCategory = table.Column<int>(type: "int", nullable: false),
                    idBrand = table.Column<int>(type: "int", nullable: false),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_idBrand",
                        column: x => x.idBrand,
                        principalTable: "Brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_CategoryChildren_idCategory",
                        column: x => x.idCategory,
                        principalTable: "CategoryChildren",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_idBrand",
                table: "Product",
                column: "idBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Product_idCategory",
                table: "Product",
                column: "idCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
