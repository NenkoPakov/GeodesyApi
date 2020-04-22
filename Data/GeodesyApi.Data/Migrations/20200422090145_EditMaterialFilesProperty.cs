using Microsoft.EntityFrameworkCore.Migrations;

namespace GeodesyApi.Data.Migrations
{
    public partial class EditMaterialFilesProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialsId",
                table: "MaterialsFiles");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialsFiles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialsFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MaterialsId",
                table: "MaterialsFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
