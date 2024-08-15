using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SONA.Migrations
{
    /// <inheritdoc />
    public partial class Hoootel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "RoomTypeId", "BasePrice", "Capacity", "IsDelete", "TypeName" },
                values: new object[,]
                {
                    { 1, 100m, 1, false, "Single" },
                    { 2, 150m, 2, false, "Double" },
                    { 3, 250m, 3, false, "Suite" },
                    { 4, 300m, 4, false, "Family" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomId", "IsAvailable", "IsDelete", "RoomNumber", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, true, false, "101", 1 },
                    { 2, true, false, "102", 1 },
                    { 3, true, false, "103", 1 },
                    { 4, true, false, "104", 1 },
                    { 5, true, false, "105", 1 },
                    { 6, true, false, "106", 1 },
                    { 7, true, false, "107", 1 },
                    { 8, true, false, "108", 1 },
                    { 9, true, false, "109", 1 },
                    { 10, true, false, "110", 1 },
                    { 11, true, false, "111", 1 },
                    { 12, true, false, "112", 1 },
                    { 13, true, false, "113", 1 },
                    { 14, true, false, "114", 1 },
                    { 15, true, false, "115", 1 },
                    { 16, true, false, "116", 1 },
                    { 17, true, false, "117", 1 },
                    { 18, true, false, "118", 1 },
                    { 19, true, false, "119", 1 },
                    { 20, true, false, "120", 1 },
                    { 21, true, false, "121", 1 },
                    { 22, true, false, "122", 1 },
                    { 23, true, false, "123", 1 },
                    { 24, true, false, "124", 1 },
                    { 25, true, false, "125", 1 },
                    { 26, true, false, "126", 1 },
                    { 27, true, false, "127", 1 },
                    { 28, true, false, "128", 1 },
                    { 29, true, false, "129", 1 },
                    { 30, true, false, "130", 1 },
                    { 31, true, false, "201", 2 },
                    { 32, true, false, "202", 2 },
                    { 33, true, false, "203", 2 },
                    { 34, true, false, "204", 2 },
                    { 35, true, false, "205", 2 },
                    { 36, true, false, "206", 2 },
                    { 37, true, false, "207", 2 },
                    { 38, true, false, "208", 2 },
                    { 39, true, false, "209", 2 },
                    { 40, true, false, "210", 2 },
                    { 41, true, false, "211", 2 },
                    { 42, true, false, "212", 2 },
                    { 43, true, false, "213", 2 },
                    { 44, true, false, "214", 2 },
                    { 45, true, false, "215", 2 },
                    { 46, true, false, "216", 2 },
                    { 47, true, false, "217", 2 },
                    { 48, true, false, "218", 2 },
                    { 49, true, false, "219", 2 },
                    { 50, true, false, "220", 2 },
                    { 51, true, false, "221", 2 },
                    { 52, true, false, "222", 2 },
                    { 53, true, false, "223", 2 },
                    { 54, true, false, "224", 2 },
                    { 55, true, false, "225", 2 },
                    { 56, true, false, "226", 2 },
                    { 57, true, false, "227", 2 },
                    { 58, true, false, "228", 2 },
                    { 59, true, false, "229", 2 },
                    { 60, true, false, "230", 2 },
                    { 61, true, false, "301", 3 },
                    { 62, true, false, "302", 3 },
                    { 63, true, false, "303", 3 },
                    { 64, true, false, "304", 3 },
                    { 65, true, false, "305", 3 },
                    { 66, true, false, "306", 3 },
                    { 67, true, false, "307", 3 },
                    { 68, true, false, "308", 3 },
                    { 69, true, false, "309", 3 },
                    { 70, true, false, "310", 3 },
                    { 71, true, false, "311", 3 },
                    { 72, true, false, "312", 3 },
                    { 73, true, false, "313", 3 },
                    { 74, true, false, "314", 3 },
                    { 75, true, false, "315", 3 },
                    { 76, true, false, "316", 3 },
                    { 77, true, false, "317", 3 },
                    { 78, true, false, "318", 3 },
                    { 79, true, false, "319", 3 },
                    { 80, true, false, "320", 3 },
                    { 81, true, false, "321", 3 },
                    { 82, true, false, "322", 3 },
                    { 83, true, false, "323", 3 },
                    { 84, true, false, "324", 3 },
                    { 85, true, false, "325", 3 },
                    { 86, true, false, "326", 3 },
                    { 87, true, false, "327", 3 },
                    { 88, true, false, "328", 3 },
                    { 89, true, false, "329", 3 },
                    { 90, true, false, "330", 3 },
                    { 91, true, false, "401", 4 },
                    { 92, true, false, "402", 4 },
                    { 93, true, false, "403", 4 },
                    { 94, true, false, "404", 4 },
                    { 95, true, false, "405", 4 },
                    { 96, true, false, "406", 4 },
                    { 97, true, false, "407", 4 },
                    { 98, true, false, "408", 4 },
                    { 99, true, false, "409", 4 },
                    { 100, true, false, "410", 4 },
                    { 101, true, false, "411", 4 },
                    { 102, true, false, "412", 4 },
                    { 103, true, false, "413", 4 },
                    { 104, true, false, "414", 4 },
                    { 105, true, false, "415", 4 },
                    { 106, true, false, "416", 4 },
                    { 107, true, false, "417", 4 },
                    { 108, true, false, "418", 4 },
                    { 109, true, false, "419", 4 },
                    { 110, true, false, "420", 4 },
                    { 111, true, false, "421", 4 },
                    { 112, true, false, "422", 4 },
                    { 113, true, false, "423", 4 },
                    { 114, true, false, "424", 4 },
                    { 115, true, false, "425", 4 },
                    { 116, true, false, "426", 4 },
                    { 117, true, false, "427", 4 },
                    { 118, true, false, "428", 4 },
                    { 119, true, false, "429", 4 },
                    { 120, true, false, "430", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 4);
        }
    }
}
