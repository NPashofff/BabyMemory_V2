using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyMemoryV2.Migrations
{
    /// <inheritdoc />
    public partial class AddFKChildrenUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Childrens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_UserId",
                table: "Childrens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Childrens_AbpUsers_UserId",
                table: "Childrens",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Childrens_AbpUsers_UserId",
                table: "Childrens");

            migrationBuilder.DropIndex(
                name: "IX_Childrens_UserId",
                table: "Childrens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Childrens");
        }
    }
}
