namespace SONA.Models
{
    public class RoomSearchViewModel
    {
        public int SelectedRoomTypeId { get; set; }
        public int SelectedRoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int Nights { get; set; }
        public List<RoomType>? RoomTypes { get; set; }
        public List<Room>? AvailableRooms { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
