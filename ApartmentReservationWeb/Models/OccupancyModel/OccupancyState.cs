namespace ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel
{
    public class OccupancyState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Occupancy>? Occupancies { get; set; }
    }
}
