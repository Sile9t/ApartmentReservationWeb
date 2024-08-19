using ApartmentReservationWeb.Models.UserModel;

namespace ApartmentReservationWeb.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public RoleId Role { get; set; }
        public string? Languages { get; set; }
        public byte[]? Photo { get; set; }
    }
}
