using ApartmentReservationWeb.DB;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.UserModel;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace ApartmentReservationWeb.Abstractions
{
    public class UserRepository : IUserRepository
    {
        private readonly OccupancyContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public UserRepository(OccupancyContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public int AddUser(UserDto userDto)
        {
            if (_context.Users.Any(x => x.Phone == userDto.Phone))
                throw new Exception("User is already exist!");

            var entity = _mapper.Map<User>(userDto);
            _context.Users.Add(entity);

            return entity.Id;
        }

        public RoleId CheckUser(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(int id)
        {
            if (!_context.Users.Any(x => x.Id == id))
                throw new Exception("User doesn't exists!");

            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            var userDto = _mapper.Map<UserDto>(user);

            _cache.Set("user", userDto, TimeSpan.FromMinutes(30));

            return userDto;
        }

        public UserDto RemoveUser(int id)
        {
            if (_context.Users.Any(x => x.Id == id))
                throw new Exception("User doesn't exists!");

            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            
            _context.Users.Remove(user);
            _cache.Remove("user");

            return _mapper.Map<UserDto>(user);
        }

        public int UpdateUser(UserDto userDto)
        {
            if (!_context.Users.Any(x => x.Phone == userDto.Phone))
                throw new Exception("User doesn't exists!");

            var entity = _mapper.Map<User>(userDto);

            _context.Users.Update(entity);
            _cache.Set("user", userDto, TimeSpan.FromMinutes(30));

            return entity.Id;
        }
    }
}
