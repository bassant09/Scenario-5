using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppNest_Project.Migrations
{
    public partial class shelterresourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResourcesId",
                table: "Shelters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shelters_ResourcesId",
                table: "Shelters",
                column: "ResourcesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelters_Resources_ResourcesId",
                table: "Shelters",
                column: "ResourcesId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelters_Resources_ResourcesId",
                table: "Shelters");

            migrationBuilder.DropIndex(
                name: "IX_Shelters_ResourcesId",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "ResourcesId",
                table: "Shelters");
        }
    }
}
