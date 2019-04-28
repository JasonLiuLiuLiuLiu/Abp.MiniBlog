using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Abp.MiniBlog.Migrations
{
    public partial class remove_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogAndCategoriesRelations_Categories_Id",
                table: "BlogAndCategoriesRelations");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogAndCategoriesRelations",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_BlogAndCategoriesRelations_CategoriesId",
                table: "BlogAndCategoriesRelations",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogAndCategoriesRelations_Categories_CategoriesId",
                table: "BlogAndCategoriesRelations",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogAndCategoriesRelations_Categories_CategoriesId",
                table: "BlogAndCategoriesRelations");

            migrationBuilder.DropIndex(
                name: "IX_BlogAndCategoriesRelations_CategoriesId",
                table: "BlogAndCategoriesRelations");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogAndCategoriesRelations",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogAndCategoriesRelations_Categories_Id",
                table: "BlogAndCategoriesRelations",
                column: "Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
