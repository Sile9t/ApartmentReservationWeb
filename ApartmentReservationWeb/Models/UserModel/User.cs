using ApartmentReservationWeb.Models.ApartmentModel;
using ApartmentReservationWeb.Models.ApartmentModel.OccupancyModel;
using System.ComponentModel.DataAnnotations;

namespace ApartmentReservationWeb.Models.UserModel
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))
            (?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"/^\+?[1-9]\d{1,14}$/")]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string? About { get; set; }
        public string? Languages { get; set; }
        public byte[]? Photo { get; set; }
        public virtual Role? Role { get; set; }
        public RoleId RoleId { get; set; }
        public virtual List<ApartmentInfo>? Apartments { get; set; }
        public virtual int? ApartmentRulesId { get; set; }
        public virtual ApartmentRules? Rules { get; set; }
        public virtual List<Occupancy>? Occupancies { get; set; }
    }
}
