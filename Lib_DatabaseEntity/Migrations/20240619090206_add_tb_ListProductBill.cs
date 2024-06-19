using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lib_DatabaseEntity.Migrations
{
    /// <inheritdoc />
    public partial class add_tb_ListProductBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListProductBill",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    priceTotal = table.Column<float>(type: "real", nullable: false),
                    idBill = table.Column<int>(type: "int", nullable: false),
                    idProduct = table.Column<int>(type: "int", nullable: false),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListProductBill", x => x.id);
                    table.ForeignKey(
                        name: "FK_ListProductBill_Bill_idBill",
                        column: x => x.idBill,
                        principalTable: "Bill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListProductBill_Product_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListProductBill_idBill",
                table: "ListProductBill",
                column: "idBill");

            migrationBuilder.CreateIndex(
                name: "IX_ListProductBill_idProduct",
                table: "ListProductBill",
                column: "idProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListProductBill");
        }
    }
}
