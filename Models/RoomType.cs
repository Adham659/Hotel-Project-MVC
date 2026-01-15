namespace DeluxeHotelMVC.Models
{
    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }

        // Eğer fotoğraf kullanacaksan:
         // OPTIONAL (tabloda yoksa eklemeyeceğiz)
    }
}
