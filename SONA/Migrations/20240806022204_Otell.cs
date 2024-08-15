using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SONA.Migrations
{
    /// <inheritdoc />
    public partial class Otell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "UserRegistration");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserRegistration",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserRegistration");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Guest");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "UserRegistration",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
