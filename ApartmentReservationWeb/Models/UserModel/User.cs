using ApartmentReservationWeb.Abstractions;
using ApartmentReservationWeb.Models.ApartmentModel;
using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;

namespace ApartmentReservationWeb.Models.UserModel
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public virtual Role? Role { get; set; }
        public RoleId RoleId { get; set; }
        public string? About { get; set; }
        public string Languages { get; set; }
        public byte[] Photo { get; set; }
        public virtual List<ApartmentInfo>? Apartments { get; set; }
        public virtual int ApartmentRulesId { get; set; }
        public virtual ApartmentRules? Rules { get; set; }
        public virtual List<Occupancy> Occupancies { get; set; }
    }
}
