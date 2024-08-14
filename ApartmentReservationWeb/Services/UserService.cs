using ApartmentReservationWeb.Abstractions;
using ApartmentReservationWeb.DB;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models.UserModel;
using ApartmentReservationWeb.RSATools;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApartmentReservationWeb.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public int AddUser(UserDto userDto)
        {
            return _repository.AddUser(userDto);
        }

        public UserDto GetUserByPhone(string phone)
        {
            return _repository.GetUser(0);
        }

        public UserDto RemoveUser(int id)
        {
            return _repository.RemoveUser(id);
        }

        public int UpdateUser(UserDto userDto)
        {
            return _repository.UpdateUser(userDto);
        }

        public RoleId CheckUser(LoginDto loginDto)
        {
            return _repository.CheckUser(loginDto);
        }

        //To do: Login(LoginDto)

        private string GenerateToken(UserDto userDto)
        {
            var securityKey = new RsaSecurityKey(RSAExtensions.GetPrivateKey());

            var credentials = new SigningCredentials(securityKey,
                 SecurityAlgorithms.RsaSha512Signature);
            var claims = new[]
            {
                new Claim(ClaimTypes.MobilePhone, userDto.Phone),
                new Claim(ClaimTypes.Role, userDto.Role.ToString())
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
