using System.ComponentModel.DataAnnotations;

namespace ApartmentReservationWeb.Dtos
{
    public class ApartmentInfoDto
    {
        public List<byte[]>? Photos { get; set; }
        public string? Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        [Required]
        [Display(Name = "Capacity Square")]
        public double CapacitySquare { get; set; }
        [Required]
        [Display(Name = "Guests Coutn")]
        public int GuestsCount { get; set; }
        [Required]
        [Display(Name = "Beds Count")]
        public int BedsCount { get; set; }
        [Required]
        [Display(Name = "Rooms Count")]
        public int RoomsCount { get; set; }
        public string? Description { get; set; }
        [Required]
        public double Cost { get; set; }
        public double? Rate { get; set; }
        public virtual int? RulesId { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual int? HotelId { get; set; }
        public virtual int? FacilitiesInfoId { get; set; }
    }
}
