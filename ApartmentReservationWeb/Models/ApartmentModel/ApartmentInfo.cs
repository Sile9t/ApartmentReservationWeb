using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;
using ApartmentReservationWeb.Models.UserModel;

namespace ApartmentReservationWeb.Models.ApartmentModel
{
    public class ApartmentInfo
    {
        public int Id { get; set; }
        public List<byte> Photos { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double CapacitySquare { get; set; }
        public int GuestsCount { get; set; }
        public int BedsCount { get; set; }
        public int RoomsCount { get; set; }
        public string? Description { get; set; }
        public double Cost { get; set; }
        public double Rate { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual int? RulesId { get; set; }
        public virtual ApartmentRules? Rule { get; set; }
        public virtual int OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public virtual int? HotelId { get; set; }
        public virtual HotelInfo? Hotel { get; set; }
        public virtual int? FacilitiesInfoId { get; set; }
        public virtual ApartFacilities? FacilitiesInfo { get; set; }
        public virtual List<Occupancy> Occupancies { get; set; }
    }
}
