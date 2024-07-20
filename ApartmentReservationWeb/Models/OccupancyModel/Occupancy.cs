using ApartmentReservationWeb.Models.UserModel;

namespace ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel
{
    public class Occupancy
    {
        public int Id { get; set; }
        public virtual int ApartmentId { get; set; }
        public virtual ApartmentInfo Apartment { get; set; }
        public virtual int ReservedById { get; set; }
        public virtual User ReservedBy { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly OccupancyDate { get; set; }
        public DateOnly EvictionDate { get; set; }
        public virtual int OccupancyStateId { get; set; }
        public virtual OccupancyState State { get; set; }
        public virtual int ReviewId { get; set; }
        public virtual Review Review { get; set; }
        public int GuestesCount { get; set; }
        public double TotalCost { get; set; }
    }
}
