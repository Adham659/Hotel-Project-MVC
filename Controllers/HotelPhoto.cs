namespace DeluxeHotelMVC.Models
{
    public class RoomPhoto
    {
        public int PhotoID { get; set; }
        public int RoomID { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;

        public Room Room { get; set; }
    }
}
