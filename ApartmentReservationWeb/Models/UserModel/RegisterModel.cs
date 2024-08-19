using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApartmentReservationWeb.Models.UserModel
{
    public class RegisterModel : IdentityUser
    {
        //public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do no match!")]
        public string? ConfirmPassword { get; set; }
    }
}
