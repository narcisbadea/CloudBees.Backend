using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudBees.DAL.Migrations
{
    public partial class addedStatusOnAlert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Alerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Alerts");
        }
    }
}
