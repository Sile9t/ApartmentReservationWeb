using ApartmentReservationWeb.Abstractions;
using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Models;
using ApartmentReservationWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApartmentReservationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApartmentService _apartmentService;
        private readonly UserService _userService;

        public HomeController(ILogger<HomeController> logger,
             ApartmentService apartmentService, UserService userService)
        {
            _logger = logger;
            _apartmentService = apartmentService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([Bind("Phone, Password")] LoginDto loginDto)
        {
            var userId = _userService.CheckUser(loginDto, out int? Id);
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Main()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyApartments([FromBody] int? id = null)
        {
            if (id == null)
                View();

            ViewData["apartmentsList"] = _apartmentService.GetApartmentsByOwnerId(id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
