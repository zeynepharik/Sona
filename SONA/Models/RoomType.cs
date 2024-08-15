using System.ComponentModel.DataAnnotations;
namespace SONA.Models

{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string? TypeName { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public int Capacity { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
