using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudBees.DAL.Migrations
{
    public partial class AddedDescriptionAtAlerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Alerts");
        }
    }
}
