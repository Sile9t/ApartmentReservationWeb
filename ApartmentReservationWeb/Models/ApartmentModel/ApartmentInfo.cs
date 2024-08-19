using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;
using ApartmentReservationWeb.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentReservationWeb.Models.ApartmentModel
{
    public class ApartmentInfo
    {
        public int Id { get; set; }
        public List<byte>? Photos { get; set; }
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        [Display(Name = "Capacity Square")]
        public double CapacitySquare { get; set; }
        [Display(Name = "Guests Count")]
        public int GuestsCount { get; set; }
        [Display(Name = "Beds Count")]
        public int BedsCount { get; set; }
        [Display(Name = "Rooms Count")]
        public int RoomsCount { get; set; }
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "float(18, 2)")]
        public double Cost { get; set; }
        [Required]
        [Display(Name = "Extra Cost")]
        [Column(TypeName = "float(18, 2)")]
        public double? ExtraCost { get; set; }
        public double? Rate { get; set; }
        public virtual List<Review>? Reviews { get; set; }
        public virtual int? RulesId { get; set; }
        public virtual ApartmentRules? Rule { get; set; }
        public virtual string OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public virtual int? HotelId { get; set; }
        public virtual HotelInfo? Hotel { get; set; }
        public virtual int? FacilitiesInfoId { get; set; }
        public virtual ApartFacilities? FacilitiesInfo { get; set; }
        public virtual List<Occupancy>? Occupancies { get; set; }
        public virtual List<ReservationDate>? Dates { get; set; }
    }
}
