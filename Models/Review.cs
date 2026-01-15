namespace DeluxeHotelMVC.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string? PhotoUrl { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public byte Rating { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
