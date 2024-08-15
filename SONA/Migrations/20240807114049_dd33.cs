using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SONA.Migrations
{
    /// <inheritdoc />
    public partial class dd33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
           name: "FK_Reservation_Guest_GuestId",
           table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
           name: "FK_Reservation_Guest_GuestId",
           table: "Reservations",
           column: "GuestId",
           principalTable: "Guests",
           principalColumn: "GuestId",
           onDelete: ReferentialAction.Cascade);
        }
    }
}
