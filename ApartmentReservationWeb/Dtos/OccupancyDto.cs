namespace ApartmentReservationWeb.Dtos
{
    public class OccupancyDto
    {
        public virtual int ApartmentId { get; set; }
        public virtual int ReservedById { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly OccupancyDate { get; set; }
        public DateOnly EvictionDate { get; set; }
        public virtual int OccupancyStateId { get; set; }
        public virtual int ReviewId { get; set; }
        public int GuestesCount { get; set; }
        public double TotalCost { get; set; }
    }
}
