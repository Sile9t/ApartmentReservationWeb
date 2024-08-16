using System.ComponentModel.DataAnnotations;

namespace ApartmentReservationWeb.Dtos
{
    public class OccupancyDto
    {
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Occupancy Date")]
        public DateTime OccupancyDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Eviction Date")]
        public DateTime EvictionDate { get; set; }
        [Display(Name = "Guests Count")]
        public int GuestesCount { get; set; }
        [Display(Name = "Total Cost")]
        public double TotalCost { get; set; }
        public virtual int ApartmentId { get; set; }
        public virtual int ReservedById { get; set; }
        public virtual int OccupancyStateId { get; set; }
        public virtual int ReviewId { get; set; }
    }
}
