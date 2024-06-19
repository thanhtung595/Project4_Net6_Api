using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lib_DatabaseEntity.Migrations
{
    /// <inheritdoc />
    public partial class add_tb_Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    count = table.Column<int>(type: "int", nullable: false),
                    priceTotal = table.Column<float>(type: "real", nullable: false),
                    idAccount = table.Column<int>(type: "int", nullable: false),
                    idProduct = table.Column<int>(type: "int", nullable: false),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cart_Account_idAccount",
                        column: x => x.idAccount,
                        principalTable: "Account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Product_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_idAccount",
                table: "Cart",
                column: "idAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_idProduct",
                table: "Cart",
                column: "idProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
