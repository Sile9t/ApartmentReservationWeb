using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;
using ApartmentReservationWeb.Models.UserModel;

namespace ApartmentReservationWeb.Models.ApartmentModel
{
    public class ReservationDate
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public virtual int ApartmentId { get; set; }
        public virtual ApartmentInfo Apartment { get; set; }
        public virtual int ReservedById { get; set; }
        public virtual User ReservedBy { get; set; }
        public virtual int OccupancyId { get; set; }
        public virtual Occupancy Occupancy { get; set; }
        public virtual int StateId { get; set; }
        public virtual OccupancyState State { get; set; }
        public double Cost { get; set; }
        public double ExtraCharge { get; set; }
    }
}
