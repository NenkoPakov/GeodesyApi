using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeodesyApi.Data.Migrations
{
    public partial class MakeMaterialFileICollectionOfFilesAndAddUniqueStringToMaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "Materials");

            migrationBuilder.CreateTable(
                name: "MaterialsFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    MaterialUniqueString = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    FileUrl = table.Column<string>(nullable: false),
                    MaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialsFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialsFiles_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsFiles_IsDeleted",
                table: "MaterialsFiles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialsFiles_MaterialId",
                table: "MaterialsFiles",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialsFiles");

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
