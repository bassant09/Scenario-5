using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppNest_Project.Migrations
{
    public partial class shelterresoursesecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelters_Resources_ResourcesId",
                table: "Shelters");

            migrationBuilder.AlterColumn<int>(
                name: "ResourcesId",
                table: "Shelters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelters_Resources_ResourcesId",
                table: "Shelters",
                column: "ResourcesId",
                principalTable: "Resources",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shelters_Resources_ResourcesId",
                table: "Shelters");

            migrationBuilder.AlterColumn<int>(
                name: "ResourcesId",
                table: "Shelters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelters_Resources_ResourcesId",
                table: "Shelters",
                column: "ResourcesId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
