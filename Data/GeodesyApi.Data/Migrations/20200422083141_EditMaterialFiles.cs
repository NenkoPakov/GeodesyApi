using Microsoft.EntityFrameworkCore.Migrations;

namespace GeodesyApi.Data.Migrations
{
    public partial class EditMaterialFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialUniqueString",
                table: "MaterialsFiles");

            migrationBuilder.AddColumn<int>(
                name: "MaterialsId",
                table: "MaterialsFiles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialsId",
                table: "MaterialsFiles");

            migrationBuilder.AddColumn<string>(
                name: "MaterialUniqueString",
                table: "MaterialsFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
