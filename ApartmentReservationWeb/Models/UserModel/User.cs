using ApartmentReservationWeb.Models.ApartmentModel;

namespace ApartmentReservationWeb.Models.UserModel
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public string? About { get; set; }
        public string Languages { get; set; }
        public byte[] Photo { get; set; }
        public virtual List<ApartmentInfo>? Apartments { get; set; }
        public virtual int ApartmentRulesId { get; set; }
        public virtual ApartmentRules? Rules { get; set; }
    }
}
