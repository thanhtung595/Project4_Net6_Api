using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lib_DatabaseEntity.Migrations
{
    /// <inheritdoc />
    public partial class add_tb_CategoryChildren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryChildren",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCategoryParents = table.Column<int>(type: "int", nullable: false),
                    timeCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryChildren", x => x.id);
                    table.ForeignKey(
                        name: "FK_CategoryChildren_CategoryParents_idCategoryParents",
                        column: x => x.idCategoryParents,
                        principalTable: "CategoryParents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryChildren_idCategoryParents",
                table: "CategoryChildren",
                column: "idCategoryParents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryChildren");
        }
    }
}
