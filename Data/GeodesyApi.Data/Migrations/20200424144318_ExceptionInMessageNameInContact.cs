using Microsoft.EntityFrameworkCore.Migrations;

namespace GeodesyApi.Data.Migrations
{
    public partial class ExceptionInMessageNameInContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Massage",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Contacts",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "Massage",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
