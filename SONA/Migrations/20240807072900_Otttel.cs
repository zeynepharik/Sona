using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SONA.Migrations
{
    /// <inheritdoc />
    public partial class Otttel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "RoomType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 4,
                column: "ImageUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "RoomType");
        }
    }
}
