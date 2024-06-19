using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lib_DatabaseEntity.Migrations
{
    /// <inheritdoc />
    public partial class add_tb_Bill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subTotal = table.Column<float>(type: "real", nullable: false),
                    idAccount = table.Column<int>(type: "int", nullable: false),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bill_Account_idAccount",
                        column: x => x.idAccount,
                        principalTable: "Account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_idAccount",
                table: "Bill",
                column: "idAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");
        }
    }
}
