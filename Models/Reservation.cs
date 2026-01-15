using System.ComponentModel.DataAnnotations.Schema;

namespace DeluxeHotelMVC.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        public int UserID { get; set; }
        public int RoomID { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int GuestCount { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public Room Room { get; set; } = null!;

        // PRICE – otomatik hesaplanır
        [NotMapped]
        public decimal TotalPrice =>
            Room != null && Room.RoomType != null
            ? (decimal)(CheckOutDate - CheckInDate).TotalDays * Room.RoomType.PricePerNight
            : 0;
    }
}
