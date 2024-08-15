using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SONA.Migrations
{
    /// <inheritdoc />
    public partial class Oteeel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 1,
                column: "ImageUrl",
                value: "/img/room/room-3.jpg");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 2,
                column: "ImageUrl",
                value: "/img/room/room-5.jpg");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 3,
                column: "ImageUrl",
                value: "/img/room/room-1.jpg");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 4,
                column: "ImageUrl",
                value: "/img/room/room-2.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
