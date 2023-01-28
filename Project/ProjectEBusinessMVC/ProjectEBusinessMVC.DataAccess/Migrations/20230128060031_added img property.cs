using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEBusinessMVC.DataAccess.Migrations
{
    public partial class addedimgproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "SpecialTeams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "SpecialTeams");
        }
    }
}
