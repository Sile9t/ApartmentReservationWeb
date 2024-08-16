using ApartmentReservationWeb.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel
{
    public class Occupancy
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime OccupancyDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EvictionDate { get; set; }
        [Required]
        public int GuestesCount { get; set; }
        [Required]
        [Column(TypeName = "double(18, 2)")]
        public double TotalCost { get; set; }
        public virtual int ApartmentId { get; set; }
        public virtual ApartmentInfo Apartment { get; set; }
        public virtual int ReservedById { get; set; }
        public virtual User ReservedBy { get; set; }
        public virtual int? OccupancyStateId { get; set; }
        public virtual OccupancyState? State { get; set; }
        public virtual int? ReviewId { get; set; }
        public virtual Review? Review { get; set; }
        public virtual List<ReservationDate>? Dates { get; set; }
    }
}
