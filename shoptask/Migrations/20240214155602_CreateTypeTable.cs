using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoptask.Migrations
{
    /// <inheritdoc />
    public partial class CreateTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_Type_typeId",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "blogs",
                newName: "typeID");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_typeId",
                table: "blogs",
                newName: "IX_blogs_typeID");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_Type_typeID",
                table: "blogs",
                column: "typeID",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_Type_typeID",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "typeID",
                table: "blogs",
                newName: "typeId");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_typeID",
                table: "blogs",
                newName: "IX_blogs_typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_Type_typeId",
                table: "blogs",
                column: "typeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
