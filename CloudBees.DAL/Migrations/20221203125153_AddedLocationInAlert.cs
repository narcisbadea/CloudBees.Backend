using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudBees.DAL.Migrations
{
    public partial class AddedLocationInAlert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Alerts",
                newName: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Alerts",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
