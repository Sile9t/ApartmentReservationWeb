using ApartmentReservationWeb.DB;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.UserModel;
using AutoMapper;

namespace ApartmentReservationWeb.Services
{
    public class UserService
    {
        private readonly OccupancyContext _context;
        private readonly IMapper _mapper;

        public UserService(OccupancyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int AddUser(UserDto userDto)
        {
            if (_context.Users.Any(x => x.Phone == userDto.Phone))
                throw new Exception("User with this phone number already exist!");

            var entity = _mapper.Map<User>(userDto);

            _context.Users.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public UserDto GetUserByPhone(string phone)
        {
            var user = _context.Users.FirstOrDefault(x => x.Phone == phone);

            if (user == null)
                throw new Exception("User with this phone number not exist!");

            return _mapper.Map<UserDto>(user);
        }

        public bool IsUserExists(int id)
        {
            return _context.Users.Any(user => user.Id == id);
        }

        public UserDto RemoveUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                throw new Exception("User with this phone number not exist!");

            _context.Users.Remove(user);
            _context.SaveChanges();

            return _mapper.Map<UserDto>(user);
        }

        public bool UpdateUser(UserDto userDto, int id)
        {
            if (!_context.Users.Any(x => x.Id == id))
                throw new Exception("No user like this");

            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            _context.Update(user);
            _context.SaveChanges();

            return true;
        }
    }
}
