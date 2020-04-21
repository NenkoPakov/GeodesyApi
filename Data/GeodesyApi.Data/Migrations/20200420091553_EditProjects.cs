using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeodesyApi.Data.Migrations
{
    public partial class EditProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonGeometricData_Projects_ProjectId",
                table: "NonGeometricData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUpdates_Projects_PId",
                table: "ProjectUpdates");

            migrationBuilder.DropColumn(
                name: "Access",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "BeginDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GeoJson",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectDatabase",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bbox",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hight",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Layer",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Requerst",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Srs",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Width",
                table: "Projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Projectss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ParentId = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ProjectDatabase = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    BeginDate = table.Column<DateTime>(type: "date", nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    Access = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    GeoJson = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projectss", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AuthorId",
                table: "Projects",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IsDeleted",
                table: "Projects",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_NonGeometricData_Projectss_ProjectId",
                table: "NonGeometricData",
                column: "ProjectId",
                principalTable: "Projectss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_AuthorId",
                table: "Projects",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUpdates_Projectss_PId",
                table: "ProjectUpdates",
                column: "PId",
                principalTable: "Projectss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonGeometricData_Projectss_ProjectId",
                table: "NonGeometricData");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_AuthorId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUpdates_Projectss_PId",
                table: "ProjectUpdates");

            migrationBuilder.DropTable(
                name: "Projectss");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AuthorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_IsDeleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Bbox",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Format",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Hight",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Layer",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Requerst",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Srs",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Projects");

            migrationBuilder.AddColumn<bool>(
                name: "Access",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginDate",
                table: "Projects",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeoJson",
                table: "Projects",
                type: "text",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "Projects",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectDatabase",
                table: "Projects",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Projects",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_NonGeometricData_Projects_ProjectId",
                table: "NonGeometricData",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUpdates_Projects_PId",
                table: "ProjectUpdates",
                column: "PId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
