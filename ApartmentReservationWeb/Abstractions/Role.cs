using ApartmentReservationWeb.Models.UserModel;

namespace ApartmentReservationWeb.Abstractions
{
    public class Role
    {
        string Name { get; set; }
        public RoleId RoleId { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
