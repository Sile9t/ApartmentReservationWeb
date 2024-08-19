using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.UserModel;

namespace ApartmentReservationWeb.Abstractions
{
    public interface IUserRepository
    {
        string AddUser(UserDto userDto);
        UserDto GetUser(string id);
        string UpdateUser(UserDto userDto);
        UserDto RemoveUser(string id);
        RoleId CheckUser(LoginDto loginDto, out string? Id);
    }
}
