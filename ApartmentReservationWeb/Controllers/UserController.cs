using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentReservationWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] UserDto userDto)
        {
            _userService.AddUser(userDto);
            return View();
        }

        [HttpGet]
        public IActionResult Main()
        {
            return View();
        }
    }
}
