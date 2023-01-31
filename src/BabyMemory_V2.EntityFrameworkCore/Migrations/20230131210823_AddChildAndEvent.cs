using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyMemoryV2.Migrations
{
    /// <inheritdoc />
    public partial class AddChildAndEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChildrenId",
                table: "Memories",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChildrenId",
                table: "HealthProcedures",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Childrens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childrens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Childrens_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memories_ChildrenId",
                table: "Memories",
                column: "ChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthProcedures_ChildrenId",
                table: "HealthProcedures",
                column: "ChildrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_EventId",
                table: "Childrens",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthProcedures_Childrens_ChildrenId",
                table: "HealthProcedures",
                column: "ChildrenId",
                principalTable: "Childrens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Memories_Childrens_ChildrenId",
                table: "Memories",
                column: "ChildrenId",
                principalTable: "Childrens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthProcedures_Childrens_ChildrenId",
                table: "HealthProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Memories_Childrens_ChildrenId",
                table: "Memories");

            migrationBuilder.DropTable(
                name: "Childrens");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Memories_ChildrenId",
                table: "Memories");

            migrationBuilder.DropIndex(
                name: "IX_HealthProcedures_ChildrenId",
                table: "HealthProcedures");

            migrationBuilder.DropColumn(
                name: "ChildrenId",
                table: "Memories");

            migrationBuilder.DropColumn(
                name: "ChildrenId",
                table: "HealthProcedures");
        }
    }
}
