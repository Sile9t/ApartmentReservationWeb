using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;
using ApartmentReservationWeb.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentReservationWeb.Models.ApartmentModel
{
    public class ReservationDate
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double? Cost { get; set; }
        [Column(TypeName = "float(18, 2)")]
        public double? ExtraCharge { get; set; }
        [Required]
        public virtual int ApartmentId { get; set; }
        [Required]
        public virtual ApartmentInfo Apartment { get; set; }
        [Required]
        public virtual Guid ReservedById { get; set; }
        [Required]
        public virtual User ReservedBy { get; set; }
        public virtual int? OccupancyId { get; set; }
        public virtual Occupancy? Occupancy { get; set; }
        public virtual int? StateId { get; set; }
        public virtual OccupancyState? State { get; set; }
    }
}
