using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.UserModel;

namespace ApartmentReservationWeb.Abstractions
{
    public interface IUserRepository
    {
        int AddUser(UserDto userDto);
        UserDto GetUser(int id);
        int UpdateUser(UserDto userDto);
        UserDto RemoveUser(int id);
        RoleId CheckUser(LoginDto loginDto, out int? Id);
    }
}
