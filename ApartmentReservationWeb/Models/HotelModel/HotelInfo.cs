namespace ApartmentReservationWeb.Models.ApartmentModel
{
    public class HotelInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }
        public int RoomsCount { get; set; }
        public DateOnly BuildingDate { get; set; }
    }
}
