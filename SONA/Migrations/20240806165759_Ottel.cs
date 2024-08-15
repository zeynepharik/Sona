using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SONA.Migrations
{
    /// <inheritdoc />
    public partial class Ottel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
            name: "PK_UserRegistration",
            table: "UserRegistration");

            // Mevcut UserId sütununu kaldır
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRegistration");

            // Yeni UserId sütununu ekle, IDENTITY özelliği ile
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Yeni birincil anahtarı ekle
            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRegistration",
                table: "UserRegistration",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Yeni birincil anahtarı kaldır
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRegistration",
                table: "UserRegistration");

            // Yeni UserId sütununu kaldır
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRegistration");

            // Eski UserId sütununu yeniden oluştur, IDENTITY özelliği olmadan
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserRegistration",
                type: "int",
                nullable: false);

            // Eski birincil anahtarı ekle
            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRegistration",
                table: "UserRegistration",
                column: "UserId");
        }
    }
}