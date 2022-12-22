using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterClone.MSSQL.Migrations
{
    public partial class Updatedtweets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdentityName",
                table: "Users",
                newName: "UniqueName");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UniqueName",
                table: "Tweets",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Tweets",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UniqueName",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Tweets");

            migrationBuilder.RenameColumn(
                name: "UniqueName",
                table: "Users",
                newName: "IdentityName");
        }
    }
}
