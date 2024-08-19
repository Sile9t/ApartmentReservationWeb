using System.ComponentModel.DataAnnotations;

namespace ApartmentReservationWeb.Dtos
{
    public class LoginDto
    {
        public string? Id { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
