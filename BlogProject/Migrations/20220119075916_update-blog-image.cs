using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.Migrations
{
    public partial class updateblogimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_BlogId",
                table: "BlogImages",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages");

            migrationBuilder.DropIndex(
                name: "IX_BlogImages_BlogId",
                table: "BlogImages");
        }
    }
}
