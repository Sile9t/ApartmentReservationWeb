using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;
using ApartmentReservationWeb.Models.ApartmentModel;
using ApartmentReservationWeb.Models.UserModel;
using System.ComponentModel.DataAnnotations;

namespace ApartmentReservationWeb.Dtos
{
    public class ReservationDateDto
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double? Cost { get; set; }
        [Display(Name = "Extra Charge")]
        public double ExtraCharge { get; set; }
        public virtual int ApartmentId { get; set; }
        public virtual ApartmentInfo Apartment { get; set; }
        public virtual int ReservedById { get; set; }
        public virtual User ReservedBy { get; set; }
        public virtual int OccupancyId { get; set; }
        public virtual Occupancy Occupancy { get; set; }
        public virtual int StateId { get; set; }
        public virtual OccupancyState State { get; set; }
    }
}
