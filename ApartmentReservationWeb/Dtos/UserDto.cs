namespace ApartmentReservationWeb.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public string Languages { get; set; }
        public byte[] Photo { get; set; }
    }
}
