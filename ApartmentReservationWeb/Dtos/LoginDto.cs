using System.ComponentModel.DataAnnotations;

namespace ApartmentReservationWeb.Dtos
{
    public class LoginDto
    {
        public int? Id { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
