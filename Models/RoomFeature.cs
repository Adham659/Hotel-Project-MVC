namespace DeluxeHotelMVC.Models
{
    public class RoomFeature
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public int FeatureID { get; set; }

        public Room Room { get; set; }
        public Feature Feature { get; set; }
    }
}
