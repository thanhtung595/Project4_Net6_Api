using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lib_DatabaseEntity.Migrations
{
    /// <inheritdoc />
    public partial class update_colum_bill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priceCost",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "priceTotal",
                table: "ListProductBill",
                newName: "priceCost");

            migrationBuilder.AddColumn<int>(
                name: "countProduct",
                table: "ListProductBill",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countProduct",
                table: "ListProductBill");

            migrationBuilder.RenameColumn(
                name: "priceCost",
                table: "ListProductBill",
                newName: "priceTotal");

            migrationBuilder.AddColumn<float>(
                name: "priceCost",
                table: "Bill",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
