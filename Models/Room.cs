using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;

namespace DeluxeHotelMVC.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeID { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }

        public RoomType RoomType { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<RoomFeature> RoomFeatures { get; set; }
    }
}
