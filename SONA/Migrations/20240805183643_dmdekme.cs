using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SONA.Migrations
{
    /// <inheritdoc />
    public partial class dmdekme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservation_ReservationId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservation_ReservationId1",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ReservationId1",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "ReservationId1",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId2",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PaymentId",
                table: "Reservation",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservation_ReservationId",
                table: "Payment",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Payment_PaymentId",
                table: "Reservation",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservation_ReservationId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Payment_PaymentId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_PaymentId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "ReservationId2",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId1",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ReservationId1",
                table: "Payment",
                column: "ReservationId1",
                unique: true,
                filter: "[ReservationId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservation_ReservationId",
                table: "Payment",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservation_ReservationId1",
                table: "Payment",
                column: "ReservationId1",
                principalTable: "Reservation",
                principalColumn: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
