using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Companies_CompanyId",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Types_TypeId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_CompanyId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_TypeId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Card");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Card_CompanyId",
                table: "Card",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_TypeId",
                table: "Card",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Companies_CompanyId",
                table: "Card",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Types_TypeId",
                table: "Card",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
